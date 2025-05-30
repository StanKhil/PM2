﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace App.Services.Helper
{
    public class Helper
    {
          
        public String PathCombine(params String[] parts)
        {
            if(parts.Length == 0) throw new ArgumentException("'parts' must not be empty");


            char[] chars = ['/', '\\', ' '];
            LinkedList<String> list = [];
            foreach (String path in parts)
            {
                if (path.Contains("*")) throw new ArgumentException("'Invalid symbol '*'' in argument 0 ('dir*')");
                foreach (String fragment in Regex.Split(path, @"(?<!/)/(?!/)"))
                {
                    String part = fragment.Trim();
                    if (part == "" || part == ".") continue;
                    if (part == "..") list.RemoveLast();
                    else
                    {
                        int index = part.IndexOf("://");
                        if (index != -1)
                        {
                            index += 3;
                            String disk = part[..index];
                            list.AddLast(disk);
                            if (part.Length > index)
                            {
                                list.AddLast(part[index..]);
                            }   
                        }
                        else
                        {
                            list.AddLast($"/{part.TrimEnd(chars).TrimStart(chars)}");
                        }
                    }
                }
            }
                

            return String.Join("", list).Replace("///","//");
        }

    }
}
/* Д.З. Продовжити впровадження модульних тестів до 
 * курсового проєкту. Підготуватись до демонстрації проєктів.
 */
/*
 1 2 3 4 5
 ""       | 
 "1"      | garbage
 "12"     | N * N/2  -- O(N^2)
 "123"    | 
 "1234"   | 
 "12345"
 */

//comment from vs
//commet gh
