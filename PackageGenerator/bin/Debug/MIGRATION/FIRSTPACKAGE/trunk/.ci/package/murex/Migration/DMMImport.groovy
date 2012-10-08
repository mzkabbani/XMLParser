package murex.MXpress;


public class DMMImport extends Orchestrator{
	
	public RunDMMOperations(def ApplicationDirectoryPath, def MXPRESS_INSTALLER_DBVENDOR){
		FrontendUtilities utils = new FrontendUtilities();
		utils.SetUtilsAppdirPath(ApplicationDirectoryPath)
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "=================================================================================================================")
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "==========================MXpress-Installer - Stage 3 - DMM upload starts =======================================")
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "=================================================================================================================")
		
		try{
			utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== Start: DMM package import - DB vendor type: $MXPRESS_INSTALLER_DBVENDOR =====")
			def sourceFolder = ApplicationDirectoryPath+"/fs/datamart/"
				new File(sourceFolder).eachFile {
				  def fileName = it.name[0 .. it.name.lastIndexOf('.')+3];
			       def p = /(\d*-\d*-\d*-\d*-mxpk-)(.*Datamart.zip)/;
			if (  fileName ==~ p ) {
				utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"),"Renamed datamart zip");
				def s = (it.getName() =~ p).replaceFirst('$2')				    
								assert it.renameTo(new File("${it.getParent().toString()}/${s}"))

			}
		}

	
			utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"),"DBVENDOR ----- $MXPRESS_INSTALLER_DBVENDOR");
			
			if(MXPRESS_INSTALLER_DBVENDOR.equals("Sybase")){
				utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"),"DBVENDOR is SYB, Using DMM-Sybase-import.xml");
				//utils.ExecuteCommandInShell(ApplicationDirectoryPath+"/importExport.sh  fs/datamart/DMM-Sybase-import.xml > testscript.logger", new File(ApplicationDirectoryPath))

					def ant = new AntBuilder()   
					ant.exec(executable: ApplicationDirectoryPath+"/importExport.sh") {arg(line:"fs/datamart/DMM-Sybase-import.xml")}
					utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"),"Executed");
				}else{
					utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"),"DBVENDOR is Oracle, Using DMM-Oracle-import.xml");
				//utils.ExecuteCommandInShell(ApplicationDirectoryPath+"/importExport.sh  fs/datamart/DMM-Oracle-import.xml", new File(ApplicationDirectoryPath))
				def ant = new AntBuilder()   
				ant.exec(executable: ApplicationDirectoryPath+"/importExport.sh") {arg(line:"fs/datamart/DMM-Oracle-import.xml")}
				utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"),"Executed ORACLE");
				
				
			}

				utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== End: DMM package import - DB vendor type: $MXPRESS_INSTALLER_DBVENDOR =====")
			utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "=================================================================================================================")
			utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "==========================MXpress-Installer - Stage 3 - DMM package import completed =======================================")
			utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "=================================================================================================================")
		}catch(Exception ex){					
			println ex.message			
		}	
		
	}
	
}