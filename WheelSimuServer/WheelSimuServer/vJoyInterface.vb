Public Class vJoyInterface
    ' The following ifdef block is the standard way of creating macros which make exporting 
    ' from a DLL simpler. All files within this DLL are compiled with the VJOYINTERFACE_EXPORTS
    ' symbol defined on the command line. this symbol should not be defined on any project
    ' that uses this DLL. This way any other project whose source files include this file see 
    ' VJOYINTERFACE_API functions as being imported from a DLL, whereas this DLL sees symbols
    ' defined with this macro as being exported.

    '#If VJOYINTERFACE_EXPORTS Then
    '<dllexport("user32")> Function VJOYINTERFACE_API()
    '#Else
    '    <dllimport("user32")> Function VJOYINTERFACE_API()
    '#End If

        '        #if   STATIC  then
        '        #undef VJOYINTERFACE_API
        '#Const VJOYINTERFACE_API = 0
        '#End If

        '/////////////////////////// vJoy device (collection) status ////////////////////////////////////////////
#If Not VjdStat Then
#Const VJDSTAT = 0
#End If


     
    Enum VjdStat   '/* Declares an enumeration data type */
        VJD_STAT_OWN = 0    ' The  vJoy Device is owned by this application.
        VJD_STAT_FREE = 1   ' The  vJoy Device is NOT owned by any application (including this one).
        VJD_STAT_BUSY = 2   ' The  vJoy Device is owned by another application. It cannot be acquired by this application.
        VJD_STAT_MISS = 3   ' The  vJoy Device is missing. It either does not exist or the driver is down.
        VJD_STAT_UNKN = 4   ' Unknown
    End Enum

    '/* Error codes for some of the functions */
#Const NO_HANDLE_BY_INDEX = -1
#Const BAD_PREPARSED_DATA = -2
#Const NO_CAPS = -3
#Const BAD_N_BTN_CAPS = -4
#Const BAD_CALLOC = -5
#Const BAD_BTN_CAPS = -6
#Const BAD_BTN_RANGE = -7
#Const BAD_N_VAL_CAPS = -8
#Const BAD_ID_RANGE = -9
#Const NO_SUCH_AXIS = -10


    '/* Environment Variables */
#Const INTERFACE_LOG_LEVEL = "VJOYINTERFACELOGLEVEL"
#Const INTERFACE_LOG_FILE = "VJOYINTERFACELOGFILE"
#Const INTERFACE_DEF_LOG_FILE = "vJoyInterface.log"

    '/* Compatibility definitions */
#Const FFB_EFF_CONST = FFB_EFF_REPORT
#Const PFFB_EFF_CONST = PFFB_EFF_REPORT
#Const Ffb_h_Eff_Const = Ffb_h_Eff_Report

    ' Device Axis/POVs/Buttons
    Structure DEVCTRLS
        Dim Init As Boolean
        Dim Rudder As Boolean
        Dim Aileron As Boolean
        Dim AxisX As Boolean
        Dim AxisY As Boolean
        Dim AxisZ As Boolean
        Dim AxisXRot As Boolean
        Dim AxisYRot As Boolean
        Dim AxisZRot As Boolean
        Dim Slider As Boolean
        Dim Dial As Boolean
        Dim Wheel As Boolean
        Dim AxisVX As Boolean
        Dim AxisVY As Boolean
        Dim AxisVZ As Boolean
        Dim AxisVBRX As Boolean
        Dim AxisVBRY As Boolean
        Dim AxisVBRZ As Boolean
        Dim nButtons As Integer
        Dim nDescHats As Integer
        Dim nContHats As Integer
    End Structure



    'Structure DeviceStat
    '    Dim h As HANDLE                           ' Handle to the PDO interface that represents the virtual device
    '    Dim stat As VjdStat                       ' Status of the device
    '    Dim position As JOYSTICK_POSITION_V2      ' Current Position of the device
    '    Dim hDeviceNotifyHandle As HDEVNOTIFY     ' Device Notification Handle
    '    Dim DeviceControls As DEVCTRLS            ' Structure Holding the data about the device's controls
    '    Dim pPreParsedData As PVOID               ' structure contains a top-level collection's preparsed data.
    'End Structure


    'Structure DEV_INFO
    '    Dim DeviceID As Byte        ' Device ID: Valid values are 1-16
    '    Dim nImplemented As Byte    ' Number of implemented device: Valid values are 1-16
    '    Dim isImplemented As Byte   ' Is this device implemented?
    '    Dim MaxDevices As Byte      ' Maximum number of devices that may be implemented (16)
    '    Dim DriverFFB As Byte       ' Does this driver support FFB (False)
    '    Dim DeviceFFB As Byte       ' Does this device support FFB (False)
    'End Structure

    'typedef void (CALLBACK *RemovalCB)(BOOL, BOOL, PVOID)


    '    Enum FFBEType ' FFB Effect Type
    '        ' Effect Type
    '#Const ET_NONE = 0      '    No Force
    '#Const ET_CONST = 1     '    Constant Force
    '#Const ET_RAMP = 2      '    Ramp
    '#Const ET_SQR = 3       '    Square
    '#Const ET_SINE = 4      '    Sine
    '#Const ET_TRNGL = 5     '    Triangle
    '#Const ET_STUP = 6      '    Sawtooth Up
    '#Const ET_STDN = 7      '    Sawtooth Down
    '#Const ET_SPRNG = 8     '    Spring
    '#Const ET_DMPR = 9      '    Damper
    '#Const ET_INRT = 10     '    Inertia
    '#Const ET_FRCTN = 11    '    Friction
    '#Const ET_CSTM = 12     '    Custom Force Data
    '    End Enum



    '    Enum FFBPType ' FFB Packet Type
    '        ' Write
    '#Const PT_EFFREP = HID_ID_EFFREP     ' Usage Set Effect Report
    '#Const PT_ENVREP = HID_ID_ENVREP     ' Usage Set Envelope Report
    '#Const PT_CONDREP = HID_ID_CONDREP   ' Usage Set Condition Report
    '#Const PT_PRIDREP = HID_ID_PRIDREP   ' Usage Set Periodic Report
    '#Const PT_CONSTREP = HID_ID_CONSTREP ' Usage Set Constant Force Report
    '#Const PT_RAMPREP = HID_ID_RAMPREP   ' Usage Set Ramp Force Report
    '#Const PT_CSTMREP = HID_ID_CSTMREP   ' Usage Custom Force Data Report
    '#Const PT_SMPLREP = HID_ID_SMPLREP   ' Usage Download Force Sample
    '#Const PT_EFOPREP = HID_ID_EFOPREP   ' Usage Effect Operation Report
    '#Const PT_BLKFRREP = HID_ID_BLKFRREP ' Usage PID Block Free Report
    '#Const PT_CTRLREP = HID_ID_CTRLREP   ' Usage PID Device Control
    '#Const PT_GAINREP = HID_ID_GAINREP   ' Usage Device Gain Report
    '#Const PT_SETCREP = HID_ID_SETCREP   ' Usage Set Custom Force Report

    '        ' Feature
    '#Const PT_NEWEFREP = HID_ID_NEWEFREP + "0x10"   ' Usage Create New Effect Report
    '#Const PT_BLKLDREP = HID_ID_BLKLDREP + "0x10"   ' Usage Block Load Report
    '#Const PT_POOLREP = HID_ID_POOLREP + "0x10"     ' Usage PID Pool Report"
    '    End Enum


    '    Enum FFBOP
    '#Const EFF_START = 1  ' EFFECT START
    '#Const EFF_SOLO = 2   ' EFFECT SOLO START
    '#Const EFF_STOP = 3   ' EFFECT STOP
    '    End Enum



    '    Enum FFB_CTRL
    '#Const CTRL_ENACT = 1      ' Enable all device actuators.
    '#Const CTRL_DISACT = 2     ' Disable all the device actuators.
    '#Const CTRL_STOPALL = 3    ' Stop All Effects?Issues a stop on every running effect.
    '#Const CTRL_DEVRST = 4     ' Device Reset?Clears any device paused condition, enables all actuators and clears all effects from memory.
    '#Const CTRL_DEVPAUSE = 5   ' Device Pause?The all effects on the device are paused at the current time step.
    '#Const CTRL_DEVCONT = 6    ' Device Continue?The all effects that running when the device was paused are restarted from their last time step.

    '    End Enum


    '    Enum FFB_EFFECTS
    '#Const Constant = "0x0001"
    '#Const Ramp = "0x0002"
    '#Const Square = "0x0004"
    '#Const Sine = "0x0008"
    '#Const Triangle = "0x0010"
    '#Const Sawtooth_Up = "0x0020"
    '#Const Sawtooth_Dn = "0x0040"
    '#Const Spring = "0x0080"
    '#Const Damper = "0x0100"
    '#Const Inertia = "0x0200"
    '#Const Friction = "0x0400"
    '#Const Custom = "0x0800"
    '    End Enum


    'typedef struct _FFB_DATA {
    '    Dim size As ULong
    '    Dim cmd As ULong
    '	dim	*data as UCHAR
    '} FFB_DATA, * PFFB_DATA;

    'typedef struct _FFB_EFF_CONSTANT { 
    '	BYTE EffectBlockIndex; 
    '	LONG Magnitude; 			  ' Constant force magnitude: 	-10000 - 10000
    '} FFB_EFF_CONSTANT, *PFFB_EFF_CONSTANT;

    'typedef struct _FFB_EFF_RAMP {
    '	BYTE		EffectBlockIndex;
    '	LONG 		Start;             ' The Normalized magnitude at the start of the effect (-10000 - 10000)
    '	LONG 		End;               ' The Normalized magnitude at the end of the effect	(-10000 - 10000)
    '} FFB_EFF_RAMP, *PFFB_EFF_RAMP;

    '    'typedef struct _FFB_EFF_CONST {
    'typedef struct _FFB_EFF_REPORT {
    '	BYTE		EffectBlockIndex;
    '	FFBEType	EffectType;
    '	WORD		Duration;' Value in milliseconds. 0xFFFF means infinite
    '	WORD		TrigerRpt;
    '	WORD		SamplePrd;
    '	BYTE		Gain;
    '	BYTE		TrigerBtn;
    '	BOOL		Polar; ' How to interpret force direction Polar (0-360? or Cartesian (X,Y)
    '	union
    '	{
    '		BYTE	Direction; ' Polar direction: (0x00-0xFF correspond to 0-360?
    '		BYTE	DirX; ' X direction: Positive values are To the right of the center (X); Negative are Two's complement
    '	};
    '	BYTE		DirY; ' Y direction: Positive values are below the center (Y); Negative are Two's complement
    '} FFB_EFF_REPORT, *PFFB_EFF_REPORT;
    '} FFB_EFF_CONST, *PFFB_EFF_CONST;

    'typedef struct _FFB_EFF_OP {
    '	BYTE		EffectBlockIndex;
    '	FFBOP		EffectOp;
    '	BYTE		LoopCount;
    '} FFB_EFF_OP, *PFFB_EFF_OP;

    'typedef struct _FFB_EFF_PERIOD {
    '	BYTE		EffectBlockIndex;
    '	DWORD		Magnitude;			' Range: 0 - 10000
    '	LONG 		Offset;				' Range: ?0000 - 10000
    '	DWORD 		Phase;				' Range: 0 - 35999
    '	DWORD 		Period;				' Range: 0 - 32767
    '} FFB_EFF_PERIOD, *PFFB_EFF_PERIOD;

    'typedef struct _FFB_EFF_COND {
    '    Dim EffectBlockIndex As Byte
    '    Dim isY As Boolean
    '    Dim CenterPointOffsetas As Long           ' CP Offset:  Range -?0000 ? 10000
    '    Dim PosCoeff As Long          ' Positive Coefficient: Range -?0000 ? 10000
    '    Dim NegCoeff As Long          ' Negative Coefficient: Range -?0000 ? 10000
    '    Dim PosSatur As DWORD         ' Positive Saturation: Range 0 ?10000
    '    Dim NegSatur As DWORD         ' Negative Saturation: Range 0 ?10000
    '    Dim DeadBand As Long          ' Dead Band: : Range 0 ?1000
    '} FFB_EFF_COND, *PFFB_EFF_COND;

    'typedef struct _FFB_EFF_ENVLP {
    '    Dim EffectBlockIndex As Byte
    '    Dim AttackLevel As DWORD  ' The Normalized magnitude of the stating point: 0 - 10000
    '    Dim FadeLevel As DWORD    ' The Normalized magnitude of the stopping point: 0 - 10000
    '    Dim AttackTime As DWORD   ' Time of the attack: 0 - 4294967295
    '    Dim FadeTime As DWORD     ' Time of the fading: 0 - 4294967295
    '} FFB_EFF_ENVLP, *PFFB_EFF_ENVLP;

    '#Const FFB_DATA_READY = WM_USER + 31

    'typedef void (CALLBACK *FfbGenCB)(PVOID, PVOID);
    '#endif


    '#ifndef STATIC
    '	extern "C" {
    '#else
    'namespace vJoyNS {
    '#End If
    '        '/////////////////////////// vJoy device (collection) Control interface /////////////////////////////////
    '        '
    '        '	These functions allow writing feeders and other applications that interface with vJoy
    '        '	It is assumed that only one vJoy top-device (= Raw PDO) exists.
    '        '	This top-level device can have up to 16 siblings (=top-level Reports/collections)
    '        '	Each sibling is refered to as a "vJoy Device" and is attributed a unique Report ID (Range: 1-16).
    '        '
    '        '	Naming convetion:
    '        '		VJD = vJoy Device
    '        '		rID = Report ID

    '#pragma warning( push )
    '#pragma warning( disable : 4995 )
    '        '///	General driver data
    '	VJOYINTERFACE_API SHORT __cdecl GetvJoyVersion(void);
    '	VJOYINTERFACE_API BOOL	__cdecl vJoyEnabled(void);
    '	VJOYINTERFACE_API PVOID	__cdecl	GetvJoyProductString(void);
    '	VJOYINTERFACE_API PVOID	__cdecl	GetvJoyManufacturerString(void);
    '	VJOYINTERFACE_API PVOID	__cdecl	GetvJoySerialNumberString(void);
    '	VJOYINTERFACE_API BOOL	__cdecl	DriverMatch(WORD * DllVer, WORD * DrvVer);
    '	VJOYINTERFACE_API VOID	__cdecl	RegisterRemovalCB(RemovalCB cb, PVOID data);
    '	VJOYINTERFACE_API BOOL	__cdecl	vJoyFfbCap(BOOL * Supported);	' Is this version of vJoy capable of FFB?
    '	VJOYINTERFACE_API BOOL	__cdecl	GetvJoyMaxDevices(int * n);	' What is the maximum possible number of vJoy devices
    '	VJOYINTERFACE_API BOOL	__cdecl	GetNumberExistingVJD(int * n);	' What is the number of vJoy devices currently enabled


    '        '///	vJoy Device properties
    '	VJOYINTERFACE_API int	__cdecl  GetVJDButtonNumber(UINT rID);	' Get the number of buttons defined in the specified VDJ
    '	VJOYINTERFACE_API int	__cdecl  GetVJDDiscPovNumber(UINT rID);	' Get the number of descrete-type POV hats defined in the specified VDJ
    '	VJOYINTERFACE_API int	__cdecl  GetVJDContPovNumber(UINT rID);	' Get the number of descrete-type POV hats defined in the specified VDJ
    '	VJOYINTERFACE_API BOOL	__cdecl  GetVJDAxisExist(UINT rID, UINT Axis); ' Test if given axis defined in the specified VDJ
    '	VJOYINTERFACE_API BOOL	__cdecl  GetVJDAxisMax(UINT rID, UINT Axis, LONG * Max); ' Get logical Maximum value for a given axis defined in the specified VDJ
    '	VJOYINTERFACE_API BOOL	__cdecl  GetVJDAxisMin(UINT rID, UINT Axis, LONG * Min); ' Get logical Minimum value for a given axis defined in the specified VDJ
    '	VJOYINTERFACE_API enum VjdStat	__cdecl	GetVJDStatus(UINT rID);			' Get the status of the specified vJoy Device.
    '        ' Added in 2.1.6
    '	VJOYINTERFACE_API BOOL	__cdecl	isVJDExists(UINT rID);					' TRUE if the specified vJoy Device exists
    '        ' Added in 2.1.8
    '	VJOYINTERFACE_API int	__cdecl	GetOwnerPid(UINT rID);					' Reurn owner's Process ID if the specified vJoy Device exists

    '        '///	Write access to vJoy Device - Basic
    '	VJOYINTERFACE_API BOOL		__cdecl	AcquireVJD(UINT rID);				' Acquire the specified vJoy Device.
    '	VJOYINTERFACE_API VOID		__cdecl	RelinquishVJD(UINT rID);			' Relinquish the specified vJoy Device.
    '	VJOYINTERFACE_API BOOL		__cdecl	UpdateVJD(UINT rID, PVOID pData);	' Update the position data of the specified vJoy Device.

    '        '///	Write access to vJoy Device - Modifyiers
    '        ' This group of functions modify the current value of the position data
    '        ' They replace the need to create a structure of position data then call UpdateVJD

    '        '// Reset functions
    '	VJOYINTERFACE_API BOOL		__cdecl	ResetVJD(UINT rID);			' Reset all controls to predefined values in the specified VDJ
    '	VJOYINTERFACE_API VOID		__cdecl	ResetAll(void);				' Reset all controls to predefined values in all VDJ
    '	VJOYINTERFACE_API BOOL		__cdecl	ResetButtons(UINT rID);		' Reset all buttons (To 0) in the specified VDJ
    '	VJOYINTERFACE_API BOOL		__cdecl	ResetPovs(UINT rID);		' Reset all POV Switches (To -1) in the specified VDJ

    '        ' Write data
    '	VJOYINTERFACE_API BOOL		__cdecl	SetAxis(LONG Value, UINT rID, UINT Axis);		' Write Value to a given axis defined in the specified VDJ 
    '	VJOYINTERFACE_API BOOL		__cdecl	SetBtn(BOOL Value, UINT rID, UCHAR nBtn);		' Write Value to a given button defined in the specified VDJ 
    '	VJOYINTERFACE_API BOOL		__cdecl	SetDiscPov(int Value, UINT rID, UCHAR nPov);	' Write Value to a given descrete POV defined in the specified VDJ 
    '	VJOYINTERFACE_API BOOL		__cdecl	SetContPov(DWORD Value, UINT rID, UCHAR nPov);	' Write Value to a given continuous POV defined in the specified VDJ 


    '#pragma region FFB Function prototypes
    '        ' Force Feedback (FFB) functions
    '	VJOYINTERFACE_API FFBEType	__cdecl	FfbGetEffect();	' Returns effect serial number if active, 0 if inactive
    '	VJOYINTERFACE_API VOID		__cdecl	FfbRegisterGenCB(FfbGenCB cb, PVOID data);
    '	__declspec(deprecated("** FfbStart function was deprecated - you can remove it from your code **")) \
    '		VJOYINTERFACE_API BOOL		__cdecl	FfbStart(UINT rID);				  ' Start the FFB queues of the specified vJoy Device.
    '	__declspec(deprecated("** FfbStop function was deprecated - you can remove it from your code **")) \
    '		VJOYINTERFACE_API VOID		__cdecl	FfbStop(UINT rID);				  ' Stop the FFB queues of the specified vJoy Device.

    '        ' Added in 2.1.6
    '	VJOYINTERFACE_API BOOL		__cdecl	IsDeviceFfb(UINT rID);
    '	VJOYINTERFACE_API BOOL		__cdecl	IsDeviceFfbEffect(UINT rID, UINT Effect);

    '        '  Force Feedback (FFB) helper functions
    '	VJOYINTERFACE_API DWORD 	__cdecl	Ffb_h_DeviceID(const FFB_DATA * Packet, int *DeviceID);
    '	VJOYINTERFACE_API DWORD 	__cdecl Ffb_h_Type(const FFB_DATA * Packet, FFBPType *Type);
    '	VJOYINTERFACE_API DWORD 	__cdecl Ffb_h_Packet(const FFB_DATA * Packet, WORD *Type, int *DataSize, BYTE *Data[]);
    '	VJOYINTERFACE_API DWORD 	__cdecl Ffb_h_EBI(const FFB_DATA * Packet, int *Index);
    '	VJOYINTERFACE_API DWORD 	__cdecl Ffb_h_Eff_Report(const FFB_DATA * Packet, FFB_EFF_REPORT*  Effect);
    '	__declspec(deprecated("** Ffb_h_Eff_Const function was deprecated - Use function Ffb_h_Eff_Report **")) \
    '	VJOYINTERFACE_API DWORD 	__cdecl Ffb_h_Eff_Const(const FFB_DATA * Packet, FFB_EFF_CONST*  Effect);
    '	VJOYINTERFACE_API DWORD		__cdecl Ffb_h_Eff_Ramp(const FFB_DATA * Packet, FFB_EFF_RAMP*  RampEffect);
    '	VJOYINTERFACE_API DWORD 	__cdecl Ffb_h_EffOp(const FFB_DATA * Packet, FFB_EFF_OP*  Operation);
    '	VJOYINTERFACE_API DWORD 	__cdecl Ffb_h_DevCtrl(const FFB_DATA * Packet, FFB_CTRL *  Control);
    '	VJOYINTERFACE_API DWORD 	__cdecl Ffb_h_Eff_Period(const FFB_DATA * Packet, FFB_EFF_PERIOD*  Effect);
    '	VJOYINTERFACE_API DWORD 	__cdecl Ffb_h_Eff_Cond(const FFB_DATA * Packet, FFB_EFF_COND*  Condition);
    '	VJOYINTERFACE_API DWORD 	__cdecl Ffb_h_DevGain(const FFB_DATA * Packet, BYTE * Gain);
    '	VJOYINTERFACE_API DWORD		__cdecl Ffb_h_Eff_Envlp(const FFB_DATA * Packet, FFB_EFF_ENVLP*  Envelope);
    '	VJOYINTERFACE_API DWORD		__cdecl Ffb_h_EffNew(const FFB_DATA * Packet, FFBEType * Effect);

    '        ' Added in 2.1.6
    '	VJOYINTERFACE_API DWORD		__cdecl Ffb_h_Eff_Constant(const FFB_DATA * Packet, FFB_EFF_CONSTANT *  ConstantEffect);
    '#pragma endregion

    '#pragma warning( pop )
    '#ifndef STATIC
    '	} ' extern "C"
    '#else
    '} ' Namespace vJoyNS
    '#End If

End Class
