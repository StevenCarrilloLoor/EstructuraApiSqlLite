using MBaqueroPTres.Repositories;

namespace MBaqueroPTres
{
    public partial class App : Application
    {
        public static BreakingBadRepo BRBARepo { get; private set; }
        public App(BreakingBadRepo repo)
        {
            InitializeComponent();

            MainPage = new AppShell();

            BRBARepo = repo;
        }
    }
}
