#include <stdio.h>
#include <math.h>

int main() {
    char fn[1000], ffn[1000];
    char prefix[1000];
    long nsize;
    long nsections;
    long esize;
    long n;
    FILE *fp, *ffp;
    int tmp;
    long cread;
    
    printf("fn = ");
    gets(fn);
    
    fp = fopen(fn, "r");
    
    if (fp == NULL) {
        perror("open file failed");
        return 0;
    }
    
    fseek(fp, 0, SEEK_END);
    nsize = ftell(fp);
    fseek(fp, 0, SEEK_SET);
    
    printf("length = ");
    scanf("%ld", &nsections);
    gets(prefix);
    
    printf("prefix = ");
    gets(prefix);
    
    esize = ceil((double)nsize / nsections);
    n = nsize / esize;
    
    for (long i = 0; i <= n; i++) {
        cread = 0;
        
        sprintf(ffn, "%s_%ld_%ld", prefix, nsections, i);
        
        ffp = fopen(ffn, "w");
        if (ffp == NULL) {
            perror("open file to write failed");
            return 0;
        }
        
        while (!feof(fp) && cread < esize) {
            tmp = fgetc(fp);
            if (tmp == EOF) {
                printf("End of file!!\n");
                fclose(ffp);
                fclose(fp);
                return 0;
            }
            fputc(tmp ^ 0x96, ffp);
            cread++;
        }
        
        fclose(ffp);
        printf("done file %ld\n", i);
    }
    
    fclose(fp);
    printf("All done\n");
    
    return 0;
}
