namespace OneMusic.WebUI.Models
{
    public class RoleAssignViewModel
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool RoleExist { get; set; }

        //Bu roller kullanıcıya atannıp atanmadığını kontrol etmek için bunları kullanıyoruz.
    }
}
