# 🐍 炫酷贪吃蛇游戏

一个基于 HTML5 Canvas 开发的炫酷贪吃蛇游戏，配备 ASP.NET Core WebAPI 后端和 MySQL 数据库，实现分数持久化存储。

![游戏截图](https://img.shields.io/badge/Game-Snake-success?style=for-the-badge&logo=html5)
![.NET Version](https://img.shields.io/badge/.NET-9.0-purple?style=for-the-badge&logo=dotnet)
![License](https://img.shields.io/badge/License-MIT-blue?style=for-the-badge)

## ✨ 特性

### 🎮 游戏功能
- **炫酷视觉效果**
  - 彩虹渐变色蛇身，动态变化
  - 发光特效和阴影效果
  - 食物脉冲动画
  - 粒子爆炸特效（吃到食物时）
  - 半透明网格背景

- **4种难度等级**
  - 🐢 简单（150ms）- 适合新手
  - 🚶 中等（100ms）- 默认难度
  - 🏃 困难（60ms）- 速度较快
  - 🚀 地狱（35ms）- 极限挑战

- **完整的游戏控制**
  - 方向键控制移动
  - 触摸滑动支持（移动端）
  - 空格键暂停/继续
  - 开始/暂停按钮

- **分数系统**
  - 实时分数显示
  - 最高分记录（本地存储）
  - 分数自动保存到数据库

### 🔧 后端功能
- **RESTful API**
  - 保存游戏分数
  - 查询分数记录
  - 获取高分榜（前10名）

- **数据持久化**
  - EF Core + MySQL
  - Code First 模式
  - 自动时间戳

## 🛠️ 技术栈

### 前端
- HTML5 Canvas
- JavaScript (ES6+)
- CSS3 动画和渐变

### 后端
- ASP.NET Core 9.0 WebAPI
- Entity Framework Core 9.0
- Pomelo.EntityFrameworkCore.MySql

### 数据库
- MySQL 8.0.28

## 📦 项目结构

```
snake-game/
├── snake-game.html          # 游戏前端页面
├── SnakeApi/                # 后端API项目
│   ├── SnakeApi.sln         # 解决方案文件
│   └── SnakeApi/            # WebAPI项目
│       ├── Controllers/     # API控制器
│       ├── Data/            # 数据库上下文
│       ├── Models/          # 数据模型
│       ├── Migrations/      # 数据库迁移
│       └── appsettings.json # 配置文件
└── .gitignore               # Git忽略配置
```

## 🚀 快速开始

### 前置要求

- .NET 9.0 SDK
- MySQL 8.0+
- 现代浏览器（Chrome、Firefox、Edge等）

### 安装步骤

1. **克隆项目**
```bash
git clone https://github.com/zhangsan00125/snake-game.git
cd snake-game
```

2. **配置数据库连接**

编辑 `SnakeApi/SnakeApi/appsettings.json`，修改数据库连接字符串：

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;port=3306;uid=root;pwd=your_password;database=snake;AllowLoadLocalInfile=true;"
  }
}
```

3. **创建数据库**

```bash
cd SnakeApi/SnakeApi
dotnet ef database update
```

4. **启动后端API**

```bash
dotnet run
```

API将运行在 `http://localhost:5294`

5. **打开游戏**

直接在浏览器中打开 `snake-game.html` 文件即可开始游戏。

## 🎯 使用说明

### 游戏操作

- **开始游戏**：选择难度后点击"开始游戏"按钮
- **控制方向**：
  - 键盘：使用方向键 ↑ ↓ ← →
  - 触摸屏：滑动控制方向
- **暂停/继续**：点击"暂停"按钮或按空格键
- **调整难度**：游戏结束后可以重新选择难度

### API 接口

#### 保存分数
```http
POST /api/Score
Content-Type: application/json

{
  "scoreValue": 100
}
```

#### 获取高分榜
```http
GET /api/Score
```

返回前10名高分记录。

#### 获取单个分数
```http
GET /api/Score/{id}
```

## 📊 数据库结构

### Scores 表

| 字段 | 类型 | 说明 |
|------|------|------|
| Id | INT | 主键，自增 |
| Score | INT | 分数 |
| Time | DATETIME | 游戏时间 |

## 🌟 游戏规则

1. 使用方向键控制蛇的移动方向
2. 吃到食物（闪烁的圆点）可以增长身体并获得10分
3. 撞到墙壁或自己的身体游戏结束
4. 挑战更高的分数和更难的难度等级！

## 🔐 安全说明

- 生产环境请修改数据库密码
- 建议使用 `appsettings.Development.json` 存储开发环境配置
- CORS 策略在生产环境需要限制为特定域名

## 🤝 贡献

欢迎提交 Issue 和 Pull Request！

1. Fork 本项目
2. 创建特性分支 (`git checkout -b feature/AmazingFeature`)
3. 提交更改 (`git commit -m 'Add some AmazingFeature'`)
4. 推送到分支 (`git push origin feature/AmazingFeature`)
5. 开启 Pull Request

## 📝 待办事项

- [ ] 添加排行榜页面
- [ ] 支持多种游戏主题
- [ ] 添加音效和背景音乐
- [ ] 实现用户系统
- [ ] 添加成就系统
- [ ] 支持多人对战模式

## 📄 许可证

本项目采用 MIT 许可证 - 查看 [LICENSE](LICENSE) 文件了解详情

## 👨‍💻 作者

**Your Name**

- GitHub: [@zhangsan00125](https://github.com/zhangsan00125)

## 🙏 致谢

- 游戏设计灵感来自经典贪吃蛇游戏
- 感谢所有开源项目的贡献者

---

⭐ 如果这个项目对你有帮助，请给它一个星标！

🤖 Generated with [Claude Code](https://claude.com/claude-code)
