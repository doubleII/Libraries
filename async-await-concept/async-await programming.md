## Table of content
* Asynchronous programming using asyc-await
* ... in arbeit
* ... in arbeit
* ... in arbeit
* Don't do that, this is not good idee

## Asynchronus programming using async-await

The idee behind this concept.
... in arbeit


# Don't do that, this is not good idee

#### Don't do that - Block the thread until the task is done.
```c# 
var readAsync = File.ReadAllLinesAsyns("file.txt");
readAsync.Wait();
```

#### Don't do that - Block the thread until the task is done.
```c# 
var readAsync = File.ReadAllLinesAsyns("file.txt");
var lines = readAsync.Result;
```

#### Is it good Idee? 
Allow as to schedule a job, in this case an Action. Takes no argument of Task<string[]> and returns void back. It means, returns a task just completed.
```c# 
var readAsync = File.ReadAllLinesAsyns("file.txt");
readAsync.ContinueWith(task => {
    // Here the task will be completed!
    // We are not sure if the task is completed. 
    
    // If you spell the file name incorrectly, you don't take a exception back. 
    // We have to check manually! Try it!
    // Like this 
    // if(task.IsFaulted)
    // {
    //    return ERROR;
    //  }
});
Console.WriteLine("You are here!");
```

#### The Magic words
We need to find something else, something simple and efficiently. Something just like a magic. Some people call this `Harry Potter programming`. 
<br/>This is like a magic, you do something and you don't need to know, what's happens, it's just works :).

Using the magic words `async-awat`:
``` c#
async Task ReadFile() {
  var lines = File.ReadAllLinesAsyns("file.txt");
  foreach( var line in lines) {
      Console.WriteLine(line);
  }
}

await ReadFile();
// this is the all magic
```


