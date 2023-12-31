﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUploadService
    {
        Task<string> UploadAsync(Stream fileStream, string fileName, string contentType);
    }
}
