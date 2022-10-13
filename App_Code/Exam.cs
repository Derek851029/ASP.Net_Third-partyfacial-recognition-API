using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Exam 的摘要描述
/// </summary>
public class Exam
{
    //EXAM QUESTIONS
    public string QID { get; set; }
    public string QuestionTitle { get; set; }
    public string QType { get; set; }
    public string QuestionItem01 { get; set; }
    public string QuestionItem02 { get; set; }
    public string QuestionItem03 { get; set; }
    public string QuestionItem04 { get; set; }
    public string answer { get; set; }
    public string UserID { get; set; }
    public DateTime createDate { get; set; }
    public string UpdateUserID { get; set; }
    public DateTime updateDate { get; set; }
    public string flag { get; set; }

    //EXAM PAPER
    public string PID { get; set; }
    public string PaperTitle { get; set;}
    public string PaperMark { get; set;}
    public string ExamTime { get; set;}

    //PAPER CONTENT
    public string EPCID { get; set; }
    public string Score { get; set; }
    public string orderNumber { get; set; }

    //EXAM
    public string EID { get; set; }
    public string Title { get; set; }
    public DateTime startDate { get; set; }
    public DateTime deadline { get; set; }

    //EXAMANSWER
    public string AID { get; set; }
    public string UserAnswer { get; set; }

    //EXAMRECORD
    public string ERID { get; set; }
    public DateTime startTime { get; set; }
    public DateTime endTime { get; set; }

    //Other
    public string Agent_Name { get; set; }
    public string TotalScore {get;set;}


    public static List<Exam> Edit_Question(string flag="0",string ID="0",string title="",string type="0",string item1="",string item2="",
        string item3="",string item4="",string answer="",string UserID="",string Date="",string status="0", string getquestion = "")
    {
        StringBuilder sqlcmd = new StringBuilder("uspExamQuestions_Edit ");
        sqlcmd.Append(" @flag = @f ");
        sqlcmd.Append(" ,@ID = @i ");
        sqlcmd.Append(" ,@Title = @t ");
        sqlcmd.Append(" ,@Type = @tp ");
        sqlcmd.Append(" ,@Item01 = @it1 ");
        sqlcmd.Append(" ,@Item02 = @it2 ");
        sqlcmd.Append(" ,@Item03 = @it3 ");
        sqlcmd.Append(" ,@Item04 = @it4 ");
        sqlcmd.Append(" ,@answer = @a ");
        sqlcmd.Append(" ,@UserID = @u ");
        sqlcmd.Append(" ,@Date = @d ");
        sqlcmd.Append(" ,@status = @s ");
        sqlcmd.Append(" ,@getquestion = @g ");

        return DBTool.Query<Exam>(sqlcmd.ToString(), new { 
            f = flag,
            i = ID,
            t = title,
            tp = type,
            it1 = item1,
            it2 = item2,
            it3 = item3,
            it4 = item4,
            a = answer,
            u = UserID,
            d = Date,
            g = getquestion,
            s = status
        }).ToList();

    }

    public static List<Exam> QuestionsSearch(string flag = "0", string type = "0", string PID = "0")
    {
        StringBuilder sqlcmd = new StringBuilder("uspExamQuestions_Search ");
        sqlcmd.Append(" @flag = @f ");
        sqlcmd.Append(" ,@type = @t ");
        sqlcmd.Append(" ,@PID = @pid ");

        return DBTool.Query<Exam>(sqlcmd.ToString(), new { 
            f = flag,
            t = type,
            pid = PID
        }).ToList();

    }


    public static List<Exam> Edit_Paper(string flag = "0", string ID = "0", string Title = "", string Mark = "", string Time = "", string UserID = "")
    {
        StringBuilder sqlcmd = new StringBuilder("uspExamPaper_Edit ");
        sqlcmd.Append(" @flag = @f ");
        sqlcmd.Append(" ,@ID = @i ");
        sqlcmd.Append(" ,@Title = @t ");
        sqlcmd.Append(" ,@Mark = @m ");
        sqlcmd.Append(" ,@Time = @tm ");
        sqlcmd.Append(" ,@UserID = @u ");

        return DBTool.Query<Exam>(sqlcmd.ToString(), new { 
            f = flag,
            i = ID,
            t = Title,
            m = Mark,
            tm = Time,
            u = UserID
        }).ToList();
    }

    public static List<Exam> PaperSearch(string flag = "0", string ID = "0")
    {
        StringBuilder sqlcmd = new StringBuilder("uspExamPaper_Search ");
        sqlcmd.Append(" @flag = @f ");
        sqlcmd.Append(" ,@ID = @i ");

        return DBTool.Query<Exam>(sqlcmd.ToString(), new { 
            f = flag,
            i = ID
        }).ToList();
    }


    public static List<Exam> PaperContent(string flag = "0", string PID = "0", string qtype = "0", string ID = "0")
    {
        StringBuilder sqlcmd = new StringBuilder("uspExamPaperContent_Search ");
        sqlcmd.Append(" @flag = @f ");
        sqlcmd.Append(" ,@PID = @p ");
        sqlcmd.Append(" ,@Qtype = @qt ");

        return DBTool.Query<Exam>(sqlcmd.ToString(), new { 
            f = flag,
            p = PID,
            qt = qtype
        }).ToList();
    }
    
    public static void PaperContent_Edit(string flag = "0", string PID = "0", string QID = "0", string Score = "0", string num = "0", string ID = "0")
    {
        StringBuilder sqlcmd = new StringBuilder("uspExamPaperContent_Edit ");
        sqlcmd.Append(" @flag = @f ");
        sqlcmd.Append(" ,@PID = @p ");
        sqlcmd.Append(" ,@QID = @q ");
        sqlcmd.Append(" ,@ID = @i ");
        sqlcmd.Append(" ,@Score = @s ");
        sqlcmd.Append(" ,@orderNumber = @o ");

        DBTool.Query<Exam>(sqlcmd.ToString(), new { 
            f = flag,
            p = PID,
            q = QID,
            i = ID,
            s = Score,
            o = num
        });
    }

    public static List<Exam> ExamSearch(string flag = "0", string UserID = "", string ID = "0")
    {
        StringBuilder sqlcmd = new StringBuilder("uspExam_Search ");
        sqlcmd.Append(" @flag = @f ");
        sqlcmd.Append(" ,@UserID = @u ");
        sqlcmd.Append(" ,@ID = @i ");


        return DBTool.Query<Exam>(sqlcmd.ToString(), new { 
            f = flag,
            u = UserID,
            i = ID
        }).ToList();
    }

    public static void ExamEdit(string flag="0", string ID = "0", string sDate="",string eDate="", string Title="",string UserID ="", string PID = "0")
    {
        StringBuilder sqlcmd = new StringBuilder("uspExam_Edit ");
        sqlcmd.Append(" @flag = @f ");
        sqlcmd.Append(" ,@PID = @p ");
        sqlcmd.Append(" ,@Title = @t ");
        sqlcmd.Append(" ,@UserID = @u ");
        sqlcmd.Append(" ,@sDate = @s ");
        sqlcmd.Append(" ,@eDate = @e ");
        sqlcmd.Append(" ,@ID = @i ");


        DBTool.Query<Exam>(sqlcmd.ToString(), new { 
            f = flag,
            p = PID,
            t = Title,
            u = UserID,
            s = sDate,
            e = eDate,
            i = ID
        });

    }

    public static void AnswerEdit(string flag="0", string ERID = "0", string EPCID = "0", string answer = "", string UserID = "", string score = "0", string ID = "0")
    {
        StringBuilder sqlcmd = new StringBuilder("uspExamAnswer_Edit ");
        sqlcmd.Append(" @flag = @f ");
        sqlcmd.Append(" ,@UserID = @u ");
        sqlcmd.Append(" ,@Score = @s ");
        sqlcmd.Append(" ,@answer = @a ");
        sqlcmd.Append(" ,@ERID = @er ");
        sqlcmd.Append(" ,@EPCID = @ep ");
        sqlcmd.Append(" ,@ID = @i ");

        DBTool.Query<Exam>(sqlcmd.ToString(), new { 
            f = flag,
            u = UserID,
            s = score,
            a = answer,
            er = ERID,
            ep = EPCID,
            i = ID
        });
    }

    public static List<Exam> AnswerSearch(string flag = "0", string EPCID = "0", string ERID = "0",string UserID = "")
    {
        StringBuilder sqlcmd = new StringBuilder("uspExamAnswer_Search ");
        sqlcmd.Append(" @flag = @f ");
        sqlcmd.Append(" ,@EPCID = @ep ");
        sqlcmd.Append(" ,@ERID = @er ");
        sqlcmd.Append(" ,@UserID = @u ");

        return DBTool.Query<Exam>(sqlcmd.ToString(), new { 
            f = flag,
            ep = EPCID,
            er = ERID,
            u = UserID
        }).ToList();
    }

    public static List<Exam> ExamRecordEdit(string flag="0", string EID = "0", string UserID = "")
    {
        StringBuilder sqlcmd = new StringBuilder("uspExamRecord_Edit ");
        sqlcmd.Append(" @flag = @f ");
        sqlcmd.Append(" ,@EID = @e ");
        sqlcmd.Append(" ,@UserID = @u ");

        return DBTool.Query<Exam>(sqlcmd.ToString(), new { 
            f = flag,
            e = EID,
            u = UserID
        }).ToList();
    }

    public static List<Exam> ExamRecordSearch(string flag = "0", string EID = "0", string UserID = "")
    {
        StringBuilder sqlcmd = new StringBuilder("uspExamRecord_Search ");
        sqlcmd.Append(" @flag = @f ");
        sqlcmd.Append(" ,@EID = @e ");
        sqlcmd.Append(" ,@UserID = @u ");

        return DBTool.Query<Exam>(sqlcmd.ToString(), new
        {
            f = flag,
            e = EID,
            u = UserID
        }).ToList();
    }

}