import System
import System.IO

def read_nuget_api_key():
  home_dir = Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%")
  key_path = home_dir + "/Dropbox/nuget-api-key.txt"
  if File.Exists(key_path):
    with input = File.OpenText(key_path):
      return input.ReadLine()
  else:
    raise Exception("NuGet API key not present. Are you Mark Embling?")

def prompt(text):
  Console.ForegroundColor = ConsoleColor.Green
  Console.Write("${text} (y/n) ")
  Console.ResetColor();
  answer = Console.ReadKey()
  Console.WriteLine()
  return answer.Key.ToString() == 'Y' or answer.Key.ToString() == 'y'