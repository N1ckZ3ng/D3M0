#include "Adder_h.h"
#include <windows.h>
#include <stdio.h>
#pragma comment(lib, "Rpcrt4.lib")
int main() {
    RPC_STATUS status;
    RPC_WSTR stringBinding = NULL;


    status = RpcStringBindingCompose(
        NULL,
        (RPC_WSTR)L"ncacn_np",
        (RPC_WSTR)L"10.37.129.6",
        (RPC_WSTR)L"\\pipe\\ADDDDDDDDD",
        NULL,
        &stringBinding
    );
  


    if (status) {

        exit(status);
    }

    status = RpcBindingFromStringBinding(stringBinding, &Adder_Binding);

    if (status) {

        exit(status);
    }


    int result = Add( 1, 3);
    printf("Result : %d\n", result);

    RpcStringFree(&stringBinding);
    RpcBindingFree(&Adder_Binding);

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