# <font color="red">EastenRed 东方红</font> :sparkling_heart:
🐒An AR game that even a monkey can easily pick up.🐵一款AR碰撞检测小游戏 
## 安装 installation
本游戏中有涉及LightShip中的语义遮蔽功能 所以需要提前在unity中配置好LightShip环境

LightShip官网：
https://lightship.dev/products/ardk/

## 项目概述 Project Overview
本项目的初衷是在天空中游玩，您可以将手机绑于无人机上体验一些新奇的飞行体验。程序内部带有Holokit双目渲染组件，您也可以选择将其带在头上沉浸式体验游戏的快乐。滑板、跑步、开车都可以打开游戏玩耍。

can:🚁 🏃‍♀️ 🛹 🚲 🛴 🚕 👨‍🦽

这个项目构想旨在为玩家提供一种新颖的飞行体验，即使在低配设备上也能流畅运行。游戏的核心是玩家控制一辆小型穿梭机，在太空中进行飞行任务。除了太空飞行外，玩家还可以在陆地上进行游戏，发现隐藏的乐趣和挑战。整个游戏将注重玩家的体验，力求为他们带来令人兴奋和愉悦的游戏体验。

游戏中，天空会变成红色。面前会出现法阵，手机触碰到法阵会加分。倒计时结束后会在前方地面生成桃花树🌺。随着现实时间的变化，画面呈现的效果也不一样。（如下图）

![GitHub Logo](https://github.com/457231201/EastenRed/blob/main/image/2.gif?raw=true)
![GitHub Logo](https://github.com/457231201/EastenRed/blob/main/image/3.gif?raw=true)

## 项目灵感🛰️ Project inspiration
项目名来源于中国🐉第一颗人造卫星东方红一号，一边播放着东方红一边升上太空。为了致敬东方红，当无人机飞起时会将播放东方红的手机投放到空中。指引箭头会跟着音乐节奏闪烁✨。
东方红红遍了半边天，所以当程序开启时天空会变成红色🟥。
东方红太阳升，开启的法阵为红色的太阳🌞，寓意着新时代的开始。

![GitHub Logo](https://github.com/457231201/EastenRed/blob/main/image/e021e3b1b56993ff33b49e186c25b83.png?raw=true)

## 功能概述及使用建议 Function Overview and Usage Recommendations
1. 🛫天空识别，可以将天空改为红色。可以在SemanticsShader 67行中修改通道数值更改颜色。
2. 🎆碰撞器系统，检测到碰撞后将旧法阵销毁并在前方随机位置生成一个新的，并劈里啪啦放烟花
3. ⏱️UI系统，得分（碰撞到法阵后加1分）；速度表盘（显示无人机或人的速度）；高度（显示高度，高度达到一定数值开始计时）；倒计时（时间计数）
4. ⬆️箭头方向标 会指向法阵位置
5. 🎵放歌功能 会循环播放东方红音乐 
6. 📸Post-process功能 法阵箭头发光特效 穿过法阵的运镜炫光特效 全局的游戏调色滤镜
6. :bangbang: 游戏建议定制内容： 

- 时间
    
    time c8 (public static int allTime = 60;) 
    
    将值设定成你想要的秒数 
- 两法阵随机距离 
    
    chufa c117（Vector3 move = new Vector3(0f,0.2f,Random.Range(2f,4f));）
    
    将值设定成你想要的变化范围
- 游戏开始高度 
    chufa c101（if (man.transform.position.y > initialYPos + 1f && hasMovedUp==false)）

    将1f改为你想要的高度 单位为米

## 👹RoadMap（我那从零开始的unity生活记录😿🙈）
本程序为大二拓展现实开发课八周课堂产物。

### 课程规划 Course Syllabus
第一到第五周 立题 储备基础知识

第六到第八周 结课作业制作 拍视频 写readme 改善增加细节 查Bug🐞

### 学习路径 Learning path
第一到第三周 C#语言基础学习 unity基础学习 

第四到第六周 渲染管线基础 VFX粒子基础 制作小练习（有三个成品）

第七周 天空识别

第八周 UI制作学习 

### 项目构想 Project concept
给这个项目构想旨在为玩家提供一种新颖的飞行体验，低配穿梭机游戏，玩着好玩的小游戏。（但没想到陆地玩也怪好玩的）

### 当前状态 Current status
实机已完全落地 可以在手机里畅玩 但美术资产上仍有提升空间

## 作者介绍 Author Introduction
3221305435 刘馨月♊🀄 

好像有什么东西烧着了，是我的心在为你燃烧~❤️‍🔥 
<img src="image/c4f52b228800546a399cab53e948149.jpg" width="250" height="250">

# English：EastenRed 
## installation
This game involves the semantic occlusion feature in LightShip, so it's necessary to configure the LightShip environment in Unity beforehand.
LightShip Official Website :https://lightship.dev/products/ardk/

## Project Overview
"The initial idea of this project is to explore the sky, where you can attach your phone to a drone to experience some novel flying experiences. The program includes the Holokit binocular rendering component, allowing you to immerse yourself in the joy of gaming by wearing it on your head. Whether skateboarding, running, or driving, you can open the game and have fun."
This project idea aims to provide players with a novel flying experience that runs smoothly even on low-spec devices. At the core of the game is players controlling a small shuttle to undertake flying missions in space. In addition to space flight, players can also engage in gameplay on land, discovering hidden fun and challenges. The entire game will prioritize player experience, striving to deliver an exciting and enjoyable gaming experience.

In the game, the sky turns red. Circles appear in front of you, and touching them with your phone earns you points. After the countdown, cherry blossom trees will spawn on the ground ahead. The visual effects change depending on the real-time passage of time.

## Project inspiration
The project name is derived from China's first artificial satellite, Dongfanghong-1, which ascended into space while playing the song "The East is Red". As a tribute to Dongfanghong, when the drone takes off, it will release smartphones playing "The East is Red" into the air. The guiding arrow will flash in sync with the music rhythm.

"Dongfanghong, the east is red" spreads across half of the sky, so when the program starts, the sky will turn red.

## Function Overview and Usage Recommendations
1. Sky recognition: You can change the sky to red. Modify the channel values in SemanticsShader line 67 to change the color.
2. Collision system: After detecting a collision, destroy the old circle and spawn a new one at a random position ahead.
3. UI system: Score (increased by 1 point when colliding with a circle); Speedometer (displays the speed of the drone or person); Altitude (displays altitude, with a countdown starting when reaching a certain altitude); Countdown timer (time counter).
4. The arrow direction indicator will point towards the position of the magic circle.
5. The music function will loop the song "The East is Red".
6. "Customization Suggestions for the Game:

- Time:
    time c8 (public static int allTime = 60;)
    Set the value to the number of seconds you desire.
- Random Distance Between Two Circles:
    chufa c117 (Vector3 move = new Vector3(0f,0.2f,Random.Range(2f,4f));)
    Set the value to the range you desire.
- Starting Height of the Game:
    chufa c101 (if (man.transform.position.y > initialYPos + 1f && hasMovedUp==false))
    Change 1f to the desired height in meters."

## RoadMap
This program is an eight-week classroom product of the sophomore augmented reality development course.

### Course Syllabus

Weeks 1 to 5: Project Proposal, Accumulation of Basic Knowledge

Weeks 6 to 8: Program Development, Video Recording, Writing README

### Learning path

Weeks 1 to 3: Learning Basic C# Language, Basic Unity

Weeks 4 to 6: Fundamental Rendering Pipeline, Basic VFX Particle, Creating Small Exercises (with three completed products)

Week 7: Sky Recognition

Week 8: Learning UI Production

### Project concept

Offer players a novel flying experience with a low-spec shuttle game, providing enjoyable gameplay with unexpectedly fun experiences even when playing on land.

### Current status
The actual machine has landed completely and can be smoothly played on mobile phones, but there is still room for improvement in artistic assets.