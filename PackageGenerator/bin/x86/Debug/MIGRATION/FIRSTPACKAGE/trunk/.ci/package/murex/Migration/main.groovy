package murex.Migration;

public class Operations {
	
	public def StartMigration(def AppDir, def logDir, def backupDir, Map<String, Object> properties){		
		println "Package Deployment Starting!"
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
		//End-Operations
		
}}




















