/*
 * Extra Features I Added:
 * I added a simple leveling system to make the program more motivating.
 * The user can see their progress as they earn more points.
 * I also added different levels to show achievement while completing goals.
 * These features go beyond the basic requirements of the project.
 */
class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
