using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SnakeApi.Data;
using SnakeApi.Models;

namespace SnakeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScoreController : ControllerBase
    {
        private readonly SnakeDbContext _context;
        private readonly ILogger<ScoreController> _logger;

        public ScoreController(SnakeDbContext context, ILogger<ScoreController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // POST: api/Score
        [HttpPost]
        public async Task<ActionResult<Score>> SaveScore([FromBody] ScoreDto scoreDto)
        {
            try
            {
                var score = new Score
                {
                    ScoreValue = scoreDto.ScoreValue,
                    Time = DateTime.Now
                };

                _context.Scores.Add(score);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Score saved successfully: {score.Id}");

                return CreatedAtAction(nameof(GetScore), new { id = score.Id }, score);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving score");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/Score/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Score>> GetScore(int id)
        {
            var score = await _context.Scores.FindAsync(id);

            if (score == null)
            {
                return NotFound();
            }

            return score;
        }

        // GET: api/Score
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Score>>> GetScores()
        {
            return await _context.Scores
                .OrderByDescending(s => s.ScoreValue)
                .Take(10)
                .ToListAsync();
        }
    }

    public class ScoreDto
    {
        public int ScoreValue { get; set; }
    }
}
