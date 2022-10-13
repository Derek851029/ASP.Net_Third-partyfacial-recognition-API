using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// ClassTemplate 的摘要描述
/// </summary>
public class ClassTemplate
{
    /// <summary>    
    /// 流水號
    /// </summary> 
    public int SYS_ID { get; set; }
    public string SYSID { get; set; }
    /// <summary>    
    /// 班次名稱    
    /// </summary> 
    public string ClassName { get; set; }
    /// <summary>    
    /// 班次時間(上午/下午)    
    /// </summary> 
    
    public DateTime? UPDATE_TIME { get; set; }
    ///
    public string START_TIME { get; set; }

    public string END_TIME { get; set; }

    public string Agent_ExtNum { get; set; }

    // ===== 雇主工資訊 =====

    public string Cust_ID { get; set; }
    public string Cust_Class { get; set; }
    public string Cust_Name { get; set; }

    // ===== 勞工資訊 =====
    public string Cust_FullName { get; set; }
    public string Labor_Country { get; set; }
    public string Labor_Valid { get; set; }
    public string Labor_ID { get; set; }
    public string Labor_PID { get; set; }
    public string Labor_RID { get; set; }
    public string Labor_EID { get; set; }
    public string Labor_EName { get; set; }
    public string Labor_CName { get; set; }
    public string Labor_Company { get; set; }
    public string Labor_Team { get; set; }
    public string Labor_Language { get; set; }
    public string Labor_Phone { get; set; }
    public string Labor_Address { get; set; }
    public string Labor_Address2 { get; set; }
    public string Labor_Room { get; set; }
    public string Service_ID { get; set; }
    public string Service_ID_HM { get; set; }
    public string Service { get; set; }
    public string Service_HM { get; set; }
    public string ServiceName { get; set; }
    public string ServiceName_HM { get; set; }
    public string Agent_ID { get; set; }
    public string Agent_Name { get; set; }
    public string Agent_Company { get; set; }
    public string Agent_Team { get; set; }
    public string Agent_Phone { get; set; }
    public string Agent_Phone_2 { get; set; }
    public string Agent_Phone_3 { get; set; }
    public string Agent_TEL { get; set; }
    public string Agent_Co_TEL { get; set; }
    public string Agent_Code { get; set; }
    public string Agent_MVPN { get; set; }
    public string Agent_Status { get; set; }
    public string Agent_Mail { get; set; }
    public string Role_ID { get; set; }
    public DateTime Time_01 { get; set; }
    public DateTime Time_02 { get; set; }
    public DateTime Time_03 { get; set; }
    public DateTime Time_04 { get; set; }
    public DateTime UpdateDate { get; set; }
    public DateTime LastUpdateDate { get; set; }
    public string CarName { get; set; }
    public string CarNumber { get; set; }
    public string PostCode { get; set; }
    public string Location { get; set; }
    public string LocationStart { get; set; }
    public string LocationEnd { get; set; }
    public string ContactName { get; set; }
    public string ContactPhone { get; set; }
    public string ContactPhone2 { get; set; }
    public string ContactPhone3 { get; set; }
    public string Contact_TEL { get; set; }
    public string Contact_Co_TEL { get; set; }
    public string Hospital { get; set; }
    public string HospitalName { get; set; }
    public string HospitalClass { get; set; }
    public string Torna { get; set; }
    public string Question { get; set; }
    public string Question2 { get; set; }
    public string Answer { get; set; }
    public string Answer2 { get; set; }
    public string UPDATE_ID { get; set; }
    public string UPDATE_Name { get; set; }
    public string Create_Company { get; set; }
    public string Create_Team { get; set; }
    public string Create_ID { get; set; }
    public string Create_Name { get; set; }
    public string Type { get; set; }
    public string Type_Value { get; set; }
    public string Chargeback { get; set; }
    public string DEPT_Status { get; set; }

    //======= 子母單 =======

    public string MNo { get; set; }
    public string CNo { get; set; }
    public string CarSeat { get; set; }
    public string CarAgent_Name { get; set; }
    public string CarAgent_Team { get; set; }
    public string Danger { get; set; }
    public string Danger_Value { get; set; }
    public string CREATE_USER { get; set; }
    public string str_time { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime OverTime { get; set; }
    public DateTime Working { get; set; }
    public DateTime WorkOff { get; set; }
    public string E_MAIL { get; set; }
    public string ConnURL { get; set; }
    public string AssignNo { get; set; }
    public string UserID { get; set; }
    public string Password { get; set; }

    public string Cancel_ID { get; set; }
    public string Cancel_Name { get; set; }
    public DateTime Cancel_Time { get; set; }
    public string Allow_ID { get; set; }
    public string Allow_Name { get; set; }
    public DateTime Allow_Time { get; set; }
    public string Close_ID { get; set; }
    public string Close_Name { get; set; }
    public DateTime Close_Time { get; set; }
    public string Dispatch_ID { get; set; }
    public string Dispatch_Name { get; set; }
    public DateTime Dispatch_Time { get; set; }

    public string Agent_LV { get; set; }
    //public string ROLE_ID { get; set; }
    public string ROLE_NAME { get; set; }
    public string OPEN_DEL { get; set; }
    public string Flag { get; set; }
    public string Flag_HM { get; set; }
    public string Flag_1 { get; set; }
    public string Flag_2 { get; set; }
    public string Flag_3 { get; set; }
    public string Flag_4 { get; set; }
    public string Flag_5 { get; set; }
    public string Flag_6 { get; set; }
    public string Del_Flag { get; set; }
    public string Email_Flag { get; set; }
    public string NowStatus { get; set; }
    public string UpDateUser { get; set; }
    public string UpDateDate { get; set; }
    public string OpenUser { get; set; }
    public string OpenUserID { get; set; }
    public DateTime OpenDate { get; set; }
    public string IP { get; set; }
}







