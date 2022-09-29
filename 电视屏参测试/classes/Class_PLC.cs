using System;

namespace Test_Automation
{
    public class Class_PLC
    {
       public static string  Move_Dis(HslCommunication.ModBus.ModbusTcpNet plc,string axis,double dis_mm)
        {
            if (axis=="x")  plc.Write(config_json.X轴相对运动坐标写入a,Convert.ToInt32( dis_mm*1000));
            if (axis == "y") plc.Write(config_json.Y轴相对运动坐标写入a, Convert.ToInt32(dis_mm * 1000));
            if (axis == "z") plc.Write(config_json.Z轴相对运动坐标写入a, Convert.ToInt32(dis_mm * 1000));

            return "设置"+axis+"移动距离：" + dis_mm;
        }
        public static string Move_Exe(HslCommunication.ModBus.ModbusTcpNet plc,string axis)
        {
            if (axis == "x") plc.Write(config_json.X轴相对运动启动a, 1);
            if (axis == "y") plc.Write(config_json.Y轴相对运动启动a, 1);
            if (axis == "z") plc.Write(config_json.Z轴相对运动启动a, 1);
            return axis +"开始移动";
        }
    }
}
