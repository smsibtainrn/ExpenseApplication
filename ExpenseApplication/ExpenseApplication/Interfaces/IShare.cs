using System.Threading.Tasks;

namespace ExpenseApplication.Interfaces
{
    public interface IShare
    {
        Task Show(string title, string message,string filePath);
    }
}
