#pragma comment(lib, "Rpcrt4.lib")
#include "Adder_h.h"

int Add(int a, int b) {
    return a + b + 10000;
}


int main() {

    RpcServerUseProtseqEp(
        (RPC_WSTR)L"ncacn_np",
        RPC_C_PROTSEQ_MAX_REQS_DEFAULT,
        (RPC_WSTR)L"\\pipe\\ADDDDDDDDD",
        NULL
    );
    RpcServerRegisterIf(Adder_v1_0_s_ifspec, NULL, NULL);
    RpcServerListen(1, RPC_C_LISTEN_MAX_CALLS_DEFAULT, FALSE);



    return 0;
}

void __RPC_FAR* __RPC_USER MIDL_user_allocate(size_t len)
{
    return(malloc(len));
}

void __RPC_USER MIDL_user_free(void __RPC_FAR* ptr)
{
    free(ptr);
}