using System;
using KeyBoardHero.Project;

namespace KeyBoardHero
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.Clear();
      Console.WriteLine("KeyBoardHero!!!\nPress any key to continue.");
      Console.ReadKey();
      Game game = new Game();
      game.Play();
    }
  }
}
