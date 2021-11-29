// intercept.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

#include "key.h"
#include "util.h"

void help(void)
{
	printf("Command line parameters:\n");
	printf("\t/ini path\to\file.ini specify alternate config file (optional)\n");
	printf("\t/apply                non-interactive, apply filters on startup (optional)\n");
}

int _tmain(int argc, _TCHAR* argv[]) {
	printf("\n*** Intercept console http://oblita.com/Interception.html\n\n");

	// Set to default, /ini switch will override
	char currDir[1024];
	GetCurrentDirectory(1024, currDir);
	char iniFile[1024];
	sprintf(iniFile, "%s\\keyremap.ini", currDir);

	int mode_apply = 0;
	for (int i=0; i<argc; i++) {
		/*if ( (stricmp(argv[i], "/help") == 0) || (stricmp(argv[i], "/?") == 0) ) {
			help();
			return 1;
		}*/

		if (stricmp(argv[i], "/apply") == 0)
			mode_apply = 1;

		if (stricmp(argv[i], "/ini") == 0) {
			if ( i == argc-1 ) {
				printf("Parameter file.ini required");
				return 1;
			}

			strcpy(iniFile, argv[i+1]);
			i++;
		}

		if (stricmp(argv[i], "/add") == 0) {
			KeyFilterSet kfs(iniFile);
			kfs.AddNew();
		}

		if (stricmp(argv[i], "/check") == 0) {
			KeyFilterSet kfs(iniFile);
			kfs.CheckInterception();
		}
	}
	KeyFilterSet kfs(iniFile);

	if ( mode_apply )
		goto apply;

	printf("This app only work when you running \"interceptGUI.EXE\"\npress any key for exit");
	getch();
	ExitProcess(1);

apply:
	printf("\n\nKeyboard filters activated.\n");
	kfs.Run();

	// not reached
	return 0;
}

