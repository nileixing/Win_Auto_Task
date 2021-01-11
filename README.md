### 简单的winform任务自动执行工具 
  - 如果你每天有很多接口要执行，需要开很多软件，你可以用这款简单的管理工具，使用visual studio。
  - 将各个接口代码写在frm_main.cs的cb_task中，然后将要执行的函数名字配置到sql server中，详情sql sever的表和配置可见脚本\sql server script\sql.txt
  - 如果你没有装sql server的话也没有关系，可以到frm_main.cs 459行代码配置
  - 你可以将.exe添加到开机启动项中