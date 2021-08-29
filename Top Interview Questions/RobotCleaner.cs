using System;
using System.Collections.Generic;
using System.Text;

namespace codetest
{
    public class Robot
    {

    }
    class RobotCleaner
    {
        HashSet<string> visited = new HashSet<string>();
        public void cleanRoom(Robot robot)
        {
            Explore(0, 0);
        }

        public void Explore(int row, int col)
        {
            var key = row + "," + col;
            if (visited.Contains(key))
            {
                return;
            }

            //Robot.Clean();
            // if(Robot.Move())
            {
                visited.Add(key);
                Explore(row, col + 1);
                Explore(row, col - 1);
                Explore(row + 1, col);
                Explore(row - 1, col);


                // return to original
                // goBack();

            }

            // Robot.Right();
        }
    }
}
       // public void goBack()
       // {
            //robot.turnRight();
            //robot.turnRight();
            //robot.move();
            //robot.turnRight();
            //robot.turnRight();
        //}
