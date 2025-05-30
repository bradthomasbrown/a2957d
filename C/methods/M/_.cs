using K32 = Kernel32                  ;
using MAL  = Mallocator               ;
using QATE = Ntdll.NtQueueApcThreadEx2;

namespace           _a2957d_  {
partial class       C         {
public static void  M(
 string code    ,
 ulong  arg0 = 0,
 ulong  arg1 = 0,
 ulong  arg2 = 0
)                             {


MAL.C m = new MAL.C(protect:K32.C.MemoryProtectionConstants.PAGE_READWRITE);
ulong prog = m.AllocByteString(code);
m.ChangeProtection(protect:K32.C.MemoryProtectionConstants.PAGE_EXECUTE_READ);
QATE.C.M(apcRoutine:prog, arg0:arg0, arg1:arg1, arg2:arg2);
m.Free();


} } }