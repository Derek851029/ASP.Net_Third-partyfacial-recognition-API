using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class FieldDefine
{

    //for ServiceStatistic Begin
    public string iTemType { get; set; }
    public string iTemPri { get; set; }
    public string iTemSub { get; set; }
    public int CallCount { get; set; }
    public decimal CallPercentage { get; set; }
    public int TTCallCount { get; set; }

    // for ServiceStatistic End---------------
    public string Subject { get; set; }
    public string Script { get; set; }
    public string UserID { get; set; }
    public string UserName { get; set; }
    public string PageName { get; set; }
    public string SubProgName { get; set; }
    public string UserIP { get; set; }
    public Int64 SysID { get; set; }
    public string TREE_ID { get; set; }
    public string TREE_NAME { get; set; }
    public string PARENT_ID { get; set; }
    public string LEVEL_ID { get; set; }
    public string SORT_ID { get; set; }
    public string IMAGE_FILE { get; set; }
    public string NAVIGATE_URL { get; set; }
    public string IS_OPEN { get; set; }
    public string GROUP_ID { get; set; }

    public int Agent_ID { get; set; }
    public string Set_Flag { get; set; }
    public string Agent_Num { get; set; }
    public string Agent_Password { get; set; }
    public string Agent_Name { get; set; }
    public string Agent_EName { get; set; }
    public string Agent_Status { get; set; }
    public DateTime? Agent_Born { get; set; }
    public string Agent_PID { get; set; }
    public DateTime? Agent_StartDate { get; set; }
    public DateTime? Agent_Enddate { get; set; }
    public string Agent_Level { get; set; }
    public string Agent_LevelExt { get; set; }
    public string Agent_DirectManager { get; set; }
    public string Agent_Backupman { get; set; }
    public string Agent_RentKind { get; set; }
    public string Agent_WorkArea { get; set; }
    public string Agent_WorkDepend { get; set; }
    public string Agent_HCountry { get; set; }
    public int? Agent_HolidayCount { get; set; }
    public DateTime? Agent_Holiday_Start { get; set; }
    public string Agent_SexKind { get; set; }
    public string Agent_BloodKind { get; set; }
    public string Agent_MarryStatus { get; set; }
    public string Agent_PHigh { get; set; }
    public string Agent_Weight { get; set; }
    public string Agent_DriverLic { get; set; }
    public string Agent_HealthStatus { get; set; }
    public string Defau_Language { get; set; }
    public string Agent_EMail { get; set; }
    public string Agent_Mail { get; set; }
    public string Agent_Class { get; set; }
    public int? Agent_CompID { get; set; }
    public string Agent_Comp { get; set; }
    public string Agent_DeptID { get; set; }
    public string Agent_DEPT { get; set; }
    public string Dept_Level { get; set; }
    public string Agent_ExtNum { get; set; }
    public string Agent_Mobile { get; set; }
    public string Agent_HTelArea { get; set; }
    public string Agent_HTel1 { get; set; }
    public string Agent_ZipNo { get; set; }
    public string Agent_Address { get; set; }
    public string Agent_ZipNo2 { get; set; }
    public string Agent_Address2 { get; set; }
    public string Contact_Person { get; set; }
    public string Contact_Tel { get; set; }
    public string Contact_Mobile { get; set; }
    public string Contact_EMail { get; set; }
    public string E_Contact_Person { get; set; }
    public string E_Contact_Tel { get; set; }
    public string E_Contact_Mobile { get; set; }
    public string Major_School { get; set; }
    public string Major_Class { get; set; }
    public string Major_Kind { get; set; }
    public string Major_License { get; set; }
    public string P_Personal { get; set; }
    public string P_Hobby { get; set; }
    public string Career_History { get; set; }
    public string P_Description { get; set; }
    public string Agent_SMS { get; set; }
    public string Buy_Stock_Flag { get; set; }
    public string Agent_Area { get; set; }
    public string equip_wh_id { get; set; }
    public string skill_level { get; set; }
    public string Agent_Skill { get; set; }
    public string Skill_Name { get; set; }
    public string ROLE_ID { get; set; }
    public string Role_Name { get; set; }
    public int Log_ID { get; set; }
    public DateTime? Time_Begin { get; set; }
    public DateTime? Time_End { get; set; }
    public string Record_File { get; set; }
    public string Local_Record_File { get; set; }
    public string Tel_Num { get; set; }
    public string Call_Type { get; set; }
    public string Call_State { get; set; }
    public string Call_Time { get; set; }
    public string Ext_Num { get; set; }
    public string Case_ID { get; set; }
    public string Cus_ID { get; set; }
    public string Bak_Num { get; set; }
    public string prj_1 { get; set; }
    public string prj_2 { get; set; }
    public string prj_3 { get; set; }
    public string prj_4 { get; set; }
    public string bak_rec_flag { get; set; }
    public int? AmountInCount { get; set; }
    public int? AmountInTime { get; set; }
    public int? AmountOutCount { get; set; }
    public int? AmountOutTime { get; set; }
    public string Check_REC { get; set; }
    public int? UPLOAD_COUNT { get; set; }
    public DateTime? UPLOAD_TIME { get; set; }
    public string FINAL_STATUS { get; set; }
    public string Filter1 { get; set; }
    public string Filter2 { get; set; }
}
