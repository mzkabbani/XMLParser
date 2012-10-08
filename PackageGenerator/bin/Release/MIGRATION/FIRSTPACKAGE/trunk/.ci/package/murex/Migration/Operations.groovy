package murex.Migration;

public class Operations {
	
	public def StartMigration(def AppDir, def logDir, def backupDir, Map<String, Object> properties){		
		println "Package Deployment Starting!" + AppDir;
		println "AppDir======>" + AppDir;
		println "logDir======>" + logDir;
		println "backupDir===>" + backupDir;		
		boolean logFileExists =  new File(AppDir+logDir+"/CustomizationsLog.log").exists();
		
		if	(logFileExists){		
		println "This Package has already been run before!";
		return;
		}
		
		FrontendUtilities frontEndUtilities = new FrontendUtilities();
		frontEndUtilities.SetUtilsAppdirPath(AppDir);
		frontEndUtilities.SetUtilsLogDir(logDir);
		frontEndUtilities.SetUtilsBackupDir(backupDir);
	
		
		
		
		
		
		
		//Start-Operations
	frontEndUtilities.AppendTextToFile( "C:/Documents and Settings/mkabbani/My Documents/My Received Files/macro00001.xml" ,"asdasd" );
	//End-Operations
		
def PROP_GenericProp = properties.get("GenericProp");


}}





















