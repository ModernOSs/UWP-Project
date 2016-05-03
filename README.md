# 现代操作系统期中Project ~

## 一、应用设计
### 1. 应用名
    钱柜
### 2. 功能概述
    大致上的功能有两条，一是对用户每月的支出和收入进行管理，二是用户可以设定一些目标，应用会督促你去完成。
### 3. 界面
<link href="//cdn.bootcss.com/bootstrap/4.0.0-alpha.2/css/bootstrap.css" rel="stylesheet">
<div class="row">
  <div class="col-xs-6 col-sm-3">
      ① 主界面<br />
      <img src="http://liuren.link/images/main.jpg" class="img-thumbnail" width = "300" height = "480" alt="主界面" align=center />
  </div>
  <div class="col-xs-6 col-sm-3">
      ② 支出收益详情<br />
      <img src="http://liuren.link/images/expence.png" class="img-thumbnail" width = "270" height = "480" alt="主界面" align=center />
  </div>
  <div class="col-xs-6 col-sm-3">
      ③ 添加支出收益<br />
      <img src="http://liuren.link/images/add.png" class="img-thumbnail" width = "270" height = "480" alt="主界面" align=center />
  </div>
  <div class="col-xs-6 col-sm-3">
      ④ 目标详情及设定<br />
      <img src="http://liuren.link/images/goal.png" class="img-thumbnail" width = "270" height = "480" alt="主界面" align=center />
  </div>
</div>
### 4. 操作逻辑
    * 点击主界面的“支出剩余”圆饼进入“支出收益详情”界面；
    * 点击“支出收益详情”界面的“添加新项”进入“添加支出收益”界面；
    * “添加支出收益”界面添加完新项后回到“支出收益详情”界面；
    * 点击主界面的右下角小加号进入“目标详情及设定”界面；
    * 更多细节将于之后更新。
### 5. 智能提醒
条件                   | 提醒
-----------------------|-----------------------
余额不足20%             |余额不足20%，要剁手啦(＞﹏＜)
余额不足40%             |本月余额还剩40%，要注意节约哦~>_<~ 
目标清单中还有未完成目标  |目标xx还没完成，去给它攥点钱吧~ + 首项未完成目标链接（可以的话）
目标清单中无未完成目标    |目前财务状况良好，给未来买点东西？ + 添加目标链接

### 6. 数据类型
类型名    |属性                             
---------|--------------------------------
收入类    |收入来源，收入数额，获得收入的时间    
支出类    |支出名称，支出数额，支出类别，支出时间 
目标类    |目标名称，目标所需的价格，计划完成时间 
收入list类|收入list，总收入                  
支出list类|支出list，总支出                  
目标list类|目标list                         
用户类    |3个list类(收入，支出，目标)，用户名  

## 二、规范
### 1. 变量名尽量用英语全称
    * 自己声明的一般变量以类似“apple”、“appleTree”方式命名；
    * 页面的变量名每个单词首字母大写；
    * 页面的变量名不以“NextPage”、“NextPage”、“MainPage2”等命名。
### 2. 合理地进行版本管理，每次完成一个小的功能就提交一下
### 3. 多写注释

## 三、工作日志
### 4月12日
    * 确定应用的功能；
    * 初定应用的界面和交互逻辑；
    * 确定分工。
### 4月15日
    * 发布任务：
    工程第一步，先完成一个可以跑的程序，然后在此基础上逐步完善。因此我们第一周就先搭一个可以运行的类似Demo的东西，不需要实现数据相关的部分。
    我们一共有五个页面，分别是主界面，支出收益详情界面，添加支出界面，添加收益界面和目标详情及设定界面。我来实现主界面（上面的那个球）和目标详情及设定界面。添加支出和收益由于很相近就由一个人负责，另一个人做支出收益详情界面，最后一个人负责页面间的链接和测试。
    我们这周虽然是完成Demo，但是为了防止给之后挖坑，Demo中要显示假的数据，该有的button要有。还有就是我们都要遵从github上面写的规范，你们想到了什么值得注意的地方也要补充到git上。
### 4月22日
    * 第一周总结：
    第一周我们按时地完成了所有页面的设计，我觉得需要改进的地方有以下三点：
    第一是应用的顶栏颜色不需要统一，具体的颜色依据该页面的样式确定；
    第二是小灰灰实现的图表为什么每次打开样式都不一样……；
    第三是分类的图标我们还没有找齐。
    * 大家这周都很忙，所以我们下一次任务的期限就定在五一节结束时。发布任务：
    完善每个人的页面的样式（图标的添加，表格颜色的修改），大家有建议都提出来。分工还是像之前那样。
    完成数据类型的声明（不管前端和方法实现，我五一节左右的时候给出详细的数据存储方法）
### 4月30日
    * 具体分工：
    刘忍：统一顶栏和每页分别的背景色；完成收入及收入list。
    小灰灰：固定图表的颜色到一个合适的值；完成支出及支出list。
    林毓：寻找分类的图片并加在“添加支出收入页”；完成目标及目标list。
    * 大家做完之后舒倩来把它们统一起来。
    * 大家每人都写一个独立的类文件，声明和实现放在一起。
    * 完成时间为下周星期五之前。
