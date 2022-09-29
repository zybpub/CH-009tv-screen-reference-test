namespace Test_Automation
{
    class PLC
    {
        public static HslCommunication.ModBus.ModbusTcpNet init() {
           HslCommunication.ModBus.ModbusTcpNet plc = new HslCommunication.ModBus.ModbusTcpNet(config_json.PLC_IP, 502, 1);   // 站号1
            plc.AddressStartWithZero = true;
            plc.DataFormat = HslCommunication.Core.DataFormat.CDAB;

            HslCommunication.OperateResult resut = plc.ConnectServer();
            if (resut.IsSuccess)
            {
                return plc;
            }
            else { return null; }
        }
        public static bool move_x(HslCommunication.ModBus.ModbusTcpNet plc,string value)
        {
            HslCommunication.OperateResult opresult = plc.Write(config_json.X轴相对运动坐标写入a, value);
            HslCommunication.OperateResult opresult2 = plc.Write(config_json.X轴相对运动启动a, 1);
            if (opresult.IsSuccess) return true;
            else return false;
        }
        public static bool move_y(HslCommunication.ModBus.ModbusTcpNet plc, string value)
        {
            HslCommunication.OperateResult opresult = plc.Write(config_json.Y轴相对运动坐标写入a, value);
            HslCommunication.OperateResult opresult2 = plc.Write(config_json.Y轴相对运动启动a, 1);
            if (opresult.IsSuccess) return true;
            else return false;
        }

        public static bool move_z(HslCommunication.ModBus.ModbusTcpNet plc, string value)
        {
            HslCommunication.OperateResult opresult = plc.Write(config_json.Z轴相对运动坐标写入a, value);
            HslCommunication.OperateResult opresult2 = plc.Write(config_json.Z轴相对运动启动a, 1);
            if (opresult.IsSuccess) return true;
            else return false;
        }
        public static bool move_r(HslCommunication.ModBus.ModbusTcpNet plc, string value)
        {
            HslCommunication.OperateResult opresult = plc.Write(config_json.R轴相对运动坐标写入a, value);
            HslCommunication.OperateResult opresult2 = plc.Write(config_json.R轴相对运动启动a, 1);
            if (opresult.IsSuccess) return true;
            else return false;
        }
    }
}
