namespace DemoBuoi03.Models
{
    public class Demo
    {
        public static string A()
        {
            Thread.Sleep(2000);
            return "Function A";
        }

        public static int B()
        {
            Thread.Sleep(5000);
            return new Random().Next();
        }

        public static void C()
        {
            Thread.Sleep(3000);
            return;
        }

        #region Method Async
        public static async Task<string> AA()
        {
            await Task.Delay(2000);
            return "Function A";
        }

        public static async Task<int> BB()
        {
            await Task.Delay(5000);
            return new Random().Next();
        }

        public static async Task CC()
        {
            await Task.Delay(3000);
            return;
        }
        #endregion
    }
}
