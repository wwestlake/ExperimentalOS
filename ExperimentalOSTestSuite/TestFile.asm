;    Assembly lanuage test file
;
;    ExperimentalOS Copyright (C) 2014  William W. Westlake Jr.
;    wwestlake@lagdaemon.com
;    
;    source code: https://github.com/wwestlake/ExperimentalOS.git 
;  
;    This program is free software: you can redistribute it and/or modify
;    it under the terms of the GNU General Public License as published by
;    the Free Software Foundation, either version 3 of the License, or
;    (at your option) any later version.
;
;    This program is distributed in the hope that it will be useful,
;    but WITHOUT ANY WARRANTY; without even the implied warranty of
;    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
;    GNU General Public License for more details.
;
;    You should have received a copy of the GNU General Public License
;    along with this program.  If not, see <http://www.gnu.org/licenses/>.
;
;    Currently a completely bogus program that is used only for testing
;    the assembler. (Don't expect this to do anything)

StartSymbol:

	Load r0, 22
	Load r1, 45
	Load r2, 1
    Call ForwardReference
	Terminate
	
ForwardReference:

    Load r3, r0, $data

BackReference:

	Sub r3, r1, r2
	JNZ  BackReference
	Return