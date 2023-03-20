using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZombieInvasion
{
    public partial class GameScreen : UserControl
    {
        int mapSize = 750;
        Map map;
        Player player;
        Pen whitePen = new Pen(Color.White);
        bool[] keyPressed = new bool[4];
        public GameScreen()
        {
            map = new Map(mapSize, 35);
            player = new Player(mapSize / 2, mapSize / 2, 100, 0.15, 50, 30);
            InitializeComponent();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            player.xSpeed = (keyPressed[3] ? 0 : player.maxSpeed) - (keyPressed[2] ? 0 : player.maxSpeed);
            player.ySpeed = (keyPressed[1] ? 0 : player.maxSpeed) - (keyPressed[0] ? 0 : player.maxSpeed);
            player.Move();
            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {

            for(int x = 0; x < mapSize; x++)
            {
                for(int y = 0; y < mapSize; y++)
                {
                    if(player.Distance(x, y) < player.viewRange)
                    {
                        e.Graphics.DrawRectangle(whitePen,
                            (int)((player.x - x) * map.tileSizeOnScreen) + this.Width/2,
                            (int)((player.y - y) * map.tileSizeOnScreen) + this.Height/2,
                            map.tileSizeOnScreen,
                            map.tileSizeOnScreen);
                    }
                }
            }

            /*for (int x = 0; x <= mapSize; x += 25)
                {
                    if (x >= player.x - this.Width && x <= player.x + this.Width)
                    {
                        e.Graphics.DrawLine(gridPen, x - player.x, 0, x - player.x, this.Height);
                    }
                }
                for (int y = 0; y <= mapSize; y += 25)
                {
                    if (y >= player.y - this.Height && y <= player.y + this.Height)
                    {
                        e.Graphics.DrawLine(gridPen, 0, y - player.y, this.Width, y - player.y);
                    }
                }*/
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    keyPressed[0] = true;
                    break;
                case Keys.S:
                    keyPressed[1] = true;
                    break;
                case Keys.A:
                    keyPressed[2] = true;
                    break;
                case Keys.D:
                    keyPressed[3] = true;
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    keyPressed[0] = false;
                    break;
                case Keys.S:
                    keyPressed[1] = false;
                    break;
                case Keys.A:
                    keyPressed[2] = false;
                    break;
                case Keys.D:
                    keyPressed[3] = false;
                    break;
            }
        }
    }
}
