/*
* AntiDupl.NET Program (http://ermig1979.github.io/AntiDupl).
*
* Copyright (c) 2002-2018 Yermalayeu Ihar.
*
* Permission is hereby granted, free of charge, to any person obtaining a copy 
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell 
* copies of the Software, and to permit persons to whom the Software is 
* furnished to do so, subject to the following conditions:
*
* The above copyright notice and this permission notice shall be included in 
* all copies or substantial portions of the Software.
*
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
* SOFTWARE.
*/
#ifndef __adFileUtils_h__
#define __adFileUtils_h__

#include "adStrings.h"
#include "adPath.h"

#define EXTENDED_PATH_PREFIX L"\\\\?\\"
#define EXTENDED_PATH_PREFIX_SIZE 4

#define DELIMETER TEXT('\\')

namespace ad
{
    //-------------------------------------------------------------------------
    bool FileDelete(const TChar *fileName, bool toRecycle = true);
    bool FileRename(const TChar *oldName, const TChar *newName);

    bool CreatePathTo(const TChar* path);
    bool ClearDirectory(const TChar* directory);

    bool IsDirectoryExists(const TChar* directoryName);	
    bool IsFileExists(const TChar* fileName);

    TString GetApplicationDirectory();
    TString GetApplicationName();
    TString GetApplicationPath();
    TString GetSystemDirectory();

    TString GetFileExtension(const TChar* path, size_t size);
    TString GetFileExtension(const TChar* path);
    inline TString GetFileExtension(const TString& path) {return GetFileExtension(path.c_str(), path.size());}

    TString GetFileName(const TChar* path, size_t size, bool withExtension = true);
    TString GetFileName(const TChar* path, bool withExtension = true);
    inline TString GetFileName(const TString& path, bool withExtension = true) {return GetFileName(path.c_str(), path.size(), withExtension);}

    TString GetFileDirectory(const TChar* path, size_t size);
    TString GetFileDirectory(const TChar* path);
    inline TString GetFileDirectory(const TString& path) {return GetFileDirectory(path.c_str(), path.size());}

    TString CreatePath(const TString& path1, const TString& path2 = TString());
    
    HGLOBAL LoadFileToMemory(const TChar* path);

	bool SearchFiles(const TString& directory, TStrings & files, bool subFolders = true, const TString & mask = TString("*"));

	bool DeleteFiles(const TString& directory, const TString& extension);

	size_t LengthOfLong(const __int64 digit);
	TString GetSimilarPath(const TPath &path);
	TString GetSimilarPath(const TPath &path, const TPath &pathForRename);

	size_t calculateIntegerLength(__int64 value);
	size_t calculateIntegerLength(unsigned __int64 value);

  TString removeNumberSuffix(const TString &name);
  TString removeNumberSuffix(const TPath &path);

  TString changeNumberSuffix(const TString &name, int delta = 1, bool force = false, bool *changed = nullptr);
  TString changeNumberSuffix(const TPath &path, int delta = 1, bool force = false, bool *changed = nullptr);

	TString extractPatternGroup(const TString &text, int index = 1);
	TString replacePatternGroup(const TString &text, const TString &replace, int index = 1);
}

#endif//__adFileUtils_h__
