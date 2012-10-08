
package murex.MXpress;

import java.io.File;

public class RTBSOperations extends Orchestrator {
	
	public RunRTBSOperations(def ApplicationDirectoryPath){
		FrontendUtilities utils = new FrontendUtilities();
		utils.SetUtilsAppdirPath(ApplicationDirectoryPath)
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "=================================================================================================================")
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "==========================MXpress-Installer - Stage 4 - RTBS setup starts =======================================")
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "=================================================================================================================")
		
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== Start: Get free port and setup as RTBS port =====")
		utils.ChmodFile(new File(ApplicationDirectoryPath+"/get_free_port.sh"), 777)
		def currentFsHost= utils.FileTextMatched(new File(ApplicationDirectoryPath+"/mxg2000_settings.sh"), /MXJ_FILESERVER_HOST=(.*)/)[0][1].toString()
		File freePortLog = new File(ApplicationDirectoryPath+"/freeport_res.log");
		freePortLog.delete();
		def random =utils.GenerateRandomNumner(32768)
		utils.ExecuteCommandInShell(ApplicationDirectoryPath+"/get_free_port.sh $random", new File(ApplicationDirectoryPath))
		utils.ChmodFile(new File(ApplicationDirectoryPath+"/freeport_res.log"), 777)
		//loading the properties file
		def freePort = utils.ReadFile(new File(ApplicationDirectoryPath+"/freeport_res.log"))
		
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "free port ==== $freePort")
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "fs host ==== ${currentFsHost}")
		
		utils.ExecuteCommandInShell(ApplicationDirectoryPath +"/launchmxj.app -scriptant /MXJ_ANT_BUILD_FILE:public.mxres.mxrtbs.RTBStargets_std.xml /MXJ_ANT_TARGET:changeServiceFeedAdapterConfig -jopt:-DconfigName=Realtime -jopt:-DadapterName=RFA_Connector -jopt:-DnickName=RTBSRFA -jopt:-DinstallationCode=LAUNCHER_RTBSRFA -jopt:-DrtbsHost=${currentFsHost} -jopt:-DrtbsPort=$freePort ", new File(ApplicationDirectoryPath))
		
		
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "=====End: Get free port and setup as RTBS port =====")
		
		
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "=================================================================================================================")
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "==========================MXpress-Installer - Stage 4 - RTBS setup completed =======================================")
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "=================================================================================================================")
		
		
	}
	
	
	
}
