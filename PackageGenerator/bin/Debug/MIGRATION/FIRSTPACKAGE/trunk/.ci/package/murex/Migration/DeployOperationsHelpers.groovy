package murex.MXpress;

import java.io.File;
import java.util.concurrent.atomic.AtomicInteger;



public class DeployOperationsHelpers extends Orchestrator{
	
	FrontendUtilities utils = new FrontendUtilities();
	def ApplicationDirectoryPath;
	def TrashDirectory;
	public UpdateLaunchers(def trashDirectory, def ApplicationDirectory){		
		utils.SetUtilsAppdirPath(ApplicationDirectoryPath);
		ApplicationDirectoryPath = ApplicationDirectory;
		TrashDirectory = trashDirectory;
		utils.DeleteDirectory(trashDirectory);
		try{
		AddFlags();}
		catch(Exception ex){
			utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), ex.message)
			
			}
	}
	
	
	public AddFlags(){
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===>/fs/public/mxres/common/launchermxpresssettings.mxres")
		public File launcherSettings = new File(ApplicationDirectoryPath+"/fs/public/mxres/common/launchermxpresssettings.mxres");
		
		public def launcherFiles ;
		if(!launcherSettings.exists()){
			return;
		}
		if(launcherFiles==null){
			launcherFiles = "launcherall.mxres"
				utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "/===>fs/public/mxres/common/$launcherFiles")
				AddDefaultCommands ( launcherSettings, ApplicationDirectoryPath+"/fs/public/mxres/common/$launcherFiles")
				
		}else{		
			for (int i = 0; i < ((List)launcherFiles).size; i++) {
				utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===>/fs/public/mxres/common/$launcherFiles[i]")
				AddDefaultCommands ( launcherSettings, ApplicationDirectoryPath+"/fs/public/mxres/common/$launcherFiles[i]")
			}
		}	
	}
	
	public AddDefaultCommands(File launcherSettings,def inputLauncher){
		
		def trashDirectory = ApplicationDirectoryPath+"/logs/MXpress-Installer/output/trash"
		new File(ApplicationDirectoryPath+"/logs/MXpress-Installer/output/trash").mkdirs()
		def nicknamesFile = trashDirectory+"/nicknames.txt"
		def tempFile = trashDirectory+"/temp.mxres"
		
		def nicknames=["MX","MXPROCESSINGSCRIPT","MXFLTAUTOFIX","MXDEALSCANNER.ENGINE"];
		
		def newNickname
		def allAdd
		def expandedFile
		for (int i = 0; i < nicknames.size(); i++) {
			newNickname = nicknames[i].toString().replace ('.', '_')			
			utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===>"+ApplicationDirectoryPath+"/CleanDeploy/launcherall/"+newNickname+".xml")
			allAdd = utils.ReadFile(new File(ApplicationDirectoryPath+"/CleanDeploy/launcherall/"+newNickname+".xml"))
			utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===>"+ApplicationDirectoryPath+"/CleanDeploy/update-launcherall-groovy.xsl")
			expandedFile=utils.ReadFile(new File(ApplicationDirectoryPath+"/CleanDeploy/update-launcherall-groovy.xsl")).toString()
			expandedFile = expandedFile.replace("#nickname#",newNickname)
			expandedFile = expandedFile.replace("#all.add#",allAdd)
			utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===>"+TrashDirectory+"/update-launcherall-groovy.xsl")
			File newFile = new File(TrashDirectory+"/update-launcherall-groovy.xsl");
			if(newFile.exists()){
				newFile.delete();				
			}
			boolean success = newFile.createNewFile();
			if (success){
				newFile.write (expandedFile);				
			}			
			utils.CopyFile(inputLauncher, tempFile)			
			sleep 30
			utils.RunXSLT(newFile, new File(inputLauncher))
			sleep 30	
		}
		
	}
	
	
	
}
