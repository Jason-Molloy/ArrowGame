using System;
using System.Collections.Generic;
using System.Timers;

namespace KeyBoardHero.Project
{
  class Game
  {
    public int Score { get; set; } = 0;
    public bool Playing { get; set; } = true;
    public int Interval { get; set; } = 1250;
    public string Target { get; set; }
    public Timer Timer { get; set; }
    public List<string> Directions { get; set; } = new List<string>() { "Up", "Right", "Down", "Left" };
    internal void Play()
    {
      Console.Clear();
      while (Playing)
      {
        SetDirection();
        SetTimer();
        PlayerInput();
        Timer.Dispose();
      }
      System.Console.WriteLine("You scored {0}", Score);
    }

    private void SetDirection()
    {
      int index = new Random().Next(4);
      Target = Directions[index];
      System.Console.WriteLine(Target);
    }

    private void SetTimer()
    {
      Timer = new Timer();
      Timer.Interval = Interval - (Score * 10);
      Timer.Elapsed += NoTimeLeft;
      Timer.Start();
    }

    private void NoTimeLeft(object sender, ElapsedEventArgs e)
    {
      Playing = false;
      Timer.Dispose();
      System.Console.WriteLine("Time ran out!\nPress spacebar to continue.");
    }

    private void PlayerInput()
    {
      string input = Console.ReadKey().Key.ToString();
      if (!input.Contains("Arrow"))
      {
        Playing = false;
        return;
      }
      input = input.Split("A")[0];
      System.Console.WriteLine(input);
      CompareDirections(input);
    }

    private void CompareDirections(string input)
    {
      if (Target != input)
      {
        Playing = false;
        return;
      }
      if (Playing)
      {
        Score++;
      }
    }
  }
}