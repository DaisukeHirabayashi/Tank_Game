#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>

int　main(){
 int sock;
 struct sockaddr_in addr;

 sock = socket(AF_INET, SOCK_DGRAM, 0);

 addr.sin_family = AF_INET;
 addr.sin_port = htons(12345);
 addr.sin_addr.s_addr = inet_addr("10.1.53.163");//送る先のIPアドレス

int leng = 1024;//送る文字列の長さ
char s[1024] = "適当な文字列を今は、打ちましょう";//文字列

 sendto(sock, s, leng, 0, (struct sockaddr *)&addr, sizeof(addr));//送るため

 close(sock);

 return 0;
}
