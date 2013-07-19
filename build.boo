solution = "MarkEmbling.Utils.sln"
configuration = "release"
test_assembly = "MarkEmbling.Utils.Tests/bin/${configuration}/MarkEmbling.Utils.Tests.dll"

target default, (compile, test, prep):
  pass

desc "Compiles the solution"
target compile:
  msbuild(file: solution, configuration: configuration, version: "4.0")

desc "Executes the tests"
target test, (compile):
  nunit(assembly: test_assembly)
  
desc "Copies the binaries to the 'bin' directory"
target prep:
  rmdir("bin")
  
  with FileList("MarkEmbling.Utils/bin/${configuration}"):
    .Include("*.{dll,exe,config}")
    .ForEach def(file):
      file.CopyToDirectory("bin")

  with FileList("MarkEmbling.Utils.Forms/bin/${configuration}"):
    .Include("*.{dll,exe,config}")
    .ForEach def(file):
      file.CopyToDirectory("bin")
