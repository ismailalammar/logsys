# logsys
this system help you to log the important information and store it somewhere in your server and revert back to it when needed,


## How it works
basically it is a function that takes two parameters: \
1 - path : the location in the server that you want to store the log -----> string \
2 - content : what you want to stroe ------> string 

```c#

                var today = DateTime.Now;

                /** check the drive name 
                 * if the drive name doesn't exist we will user the default one C://Logs//
                 * 
                **/
                string drive = Path.GetPathRoot(path);
                if (string.IsNullOrEmpty(drive))
                    path = $"C://Logs//{path}";

                path = $"{path}//{today.ToString("yyyy-MM")}";

                // create folders in the path if doesn't exist
                Directory.CreateDirectory(path);

                // add file with today's date  name to the path
                path = $"{path}//{today.ToString("yyyy-MM-dd")}.txt";

                // create the file if not exist , append to the file if exist
                using (StreamWriter sw = (File.Exists(path)) ? File.AppendText(path) : File.CreateText(path))
                {
                    sw.WriteLine($"{today} : {content}");
                }

                return $"the path : {path} successfuly created!";

```

## Note: 
make sure that you have the permission to do (read , write) on the file location , \
in the path if you didn't specific the drive location it will take the default drive path which is "C:/Logs"

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.



## License
[MIT](https://choosealicense.com/licenses/mit/)
