using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace landingpagemaker.Models;

public class Log {
    public int Id { get; set; }
    public string Message { get; set; } = "";
    public int LogType {get;set;} // 0: General, 1: Admin, 2: User
    public int TimeStamp { get; set; }
}