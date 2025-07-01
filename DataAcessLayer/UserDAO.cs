using BusinessObject;

namespace DataAcessLayer
{
    public class UserDAO
    {
        static List<User> users = new List<User>();

        public void InitializeDataset()
        {
            users.Add(new User() { Name = "Tèo", Phone = "0167201079", Email = "teo@gmail.com" });
            users.Add(new User() { Name = "Tý", Phone = "0967221079", Email = "ty@gmail.com" });
            users.Add(new User() { Name = "Bin", Phone = "0267401079", Email = "bin@gmail.com" });
            users.Add(new User() { Name = "Bo", Phone = "0747251079", Email = "bo@gmail.com" });
            users.Add(new User() { Name = "Bủm", Phone = "0267201079", Email = "bum@gmail.com" });
        }

        public List<User> GetAllUsers()
        {
            return users;
        }
    }
}
