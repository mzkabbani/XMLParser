package murex.Migration;


public enum DbType {
    SYBASE ("Sybase"),
    ORACLE ("Oracle")
    private final String name;
    DbType(String n){
        this.name=n
    }
    public String toString(){
        return name
    }   
}
