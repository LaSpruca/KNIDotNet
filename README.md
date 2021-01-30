<h1 style="text-align: center">KNIDotNet</h1>
<h6 style="text-align: center">A DotNet interface for getting notices from KAMAR </h6>
<div style="width: fit-content; margin: auto; display: flex; flex-direction: row;">
    <a style="padding: 10px;">
        <img src="https://travis-ci.com/LaSpruca/KNIDotNet.svg?branch=main" alt="Build status">
    </a>
    <a style="padding: 10px;">
        <img src="https://img.shields.io/nuget/v/LaSpruca.KNIDotNet" alt="Build status">
    </a>
</div>

This is an iterface for accessing the KAMAR API in DotNet to retrieve the notices

Example Usage:

```c#
using LaSpruca.KNIDotNet;

public class Application {
       public static async Task Main() {
            var portal = new Portal("https://demo.school.kiwi/");
            var result = await portal.GetNotices(DateTime.Now());
            Console.WriteLine(result.ToString());
       }
}
```

[Part of the KNI project](https://github.com/jacobtread/kni)
