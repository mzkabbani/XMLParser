package murex.Migration;

public class Operations {
	
	public def StartMigration(def AppDir, def logDir, def backupDir, Map<String, Object> properties){		
		println "AppDir======>" + AppDir;
		println "logDir======>" + logDir;
		println "backupDir===>" + backupDir;		
		properties.values().each { println it.toString() }
		println "====>>"+ properties.get("Customiztions_Logs_Dir");
		
		FrontendUtilities frontEndUtilities = new FrontendUtilities();
		frontEndUtilities.SetUtilsAppdirPath(AppDir);
		frontEndUtilities.SetUtilsLogDir(logDir);
		frontEndUtilities.SetUtilsBackupDir(backupDir);
		
		//Start-Operations		
		//End-Operations
		
}}




















