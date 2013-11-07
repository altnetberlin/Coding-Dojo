#I @"packages\FAKE.2.1.581-alpha\tools"
#r "FakeLib.dll"

open Fake

TraceEnvironmentVariables()

(* Directories *)
let sourceDir = @".\"

let buildDir = @".\Build\"
let testDir = buildDir
let testOutputDir = buildDir + @"Specs\"
let deployDir = @".\Release\"

(* files *)
let slnReferences = !! (sourceDir + @"*.sln")

(* Targets *)
Target "Clean" (fun _ -> 
    CleanDirs [buildDir; testDir; testOutputDir; deployDir]
)

Target "BuildApp" (fun _ ->
    MSBuildRelease buildDir "Build" slnReferences
        |> Log "AppBuild-Output: "
)

Target "Test" (fun _ ->
    !! (testDir + "/*.dll")
        |> MSpec (fun p ->
                    {p with
                        HtmlOutputDir = testOutputDir})
)

Target "Default" DoNothing

// Build order
"Clean"
  ==> "BuildApp"
  ==> "Test"
  ==> "Default"

// start build
RunParameterTargetOrDefault  "target" "Default"