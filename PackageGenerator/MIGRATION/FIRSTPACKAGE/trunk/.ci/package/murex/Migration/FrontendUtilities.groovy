package murex.Migration;

import org.codehaus.groovy.tools.shell.Shell;
import javax.xml.transform.stream.StreamSource;
import javax.xml.transform.TransformerFactory;
import groovy.lang.GroovyShell;
import org.apache.*;
import groovy.util.AntBuilder;
import groovy.util.AntBuilder;
import groovy.lang.*;
import groovy.io.*;

import java.rmi.server.Operation;
import java.util.regex.Matcher
import java.util.Random;
import java.util.regex.Pattern
import java.lang.*;
import java.awt.List;
import java.awt.geom.GeneralPath;
import java.io.*;
import groovy.util.XmlSlurper ;
import groovy.util.slurpersupport.GPathResult;
import groovy.xml.QName;

import javax.xml.transform.TransformerFactory
import javax.xml.transform.stream.StreamResult
import javax.xml.transform.stream.StreamSource
import javax.xml.xpath.*
import javax.xml.parsers.DocumentBuilderFactory

import java.io.StringWriter;
import javax.xml.transform.OutputKeys;
import javax.xml.transform.Transformer;
import javax.xml.transform.TransformerException;
import javax.xml.transform.TransformerFactory;
import javax.xml.transform.dom.DOMSource;
import javax.xml.transform.stream.StreamResult;


public  class FrontendUtilities extends Operations{

	private def AppdirPath = "";
	private def LogDir = "";
	private def BackupDir = "";
	private def LOG_FILE_NAME = "CustomizationsLog.log";

	private File LogFile = new File(AppdirPath+"/"+LOG_FILE_NAME);

	//desc-start
	//Name:AppendTextToFile
	//Description:Appends the supplied text to the given file
	//Parameter: fileName - File name to append to
	//Parameter: textToAppend - Text to append
	//desc-end
	public def AppendTextToFile(def fileName, def textToAppend){
		try{
			new File(fileName).append("\r\n"+textToAppend);
		} catch (Exception e) {
			// TODO: handle exception
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"),e.message)
		}
	}


	//desc-start
	//Name:SetUtilsLogDir
	//Description:Sets up the innitial logs directory
	//Parameter: logsDir - Path to the logs Directory
	//desc-end
	public def SetUtilsLogDir(def logsDir){
		this.LogDir = logsDir;
		println this.LogDir;
		LogFile = new File(AppdirPath+LogDir+"/"+LOG_FILE_NAME);
	}

	//desc-start
	//Name:SetUtilsBackupDir
	//Description:Sets up the backup directory
	//Parameter: backupDir - Path to the backup Directory
	//desc-end
	public def SetUtilsBackupDir(def backupDir){
		this.BackupDir = backupDir;
		println this.BackupDir;
	}

	//desc-start
	//Name:SetUtilsAppdirPath
	//Description:Sets up the application directory
	//Parameter: appdirPath - Path to the application Directory
	//desc-end
	public def SetUtilsAppdirPath(def appdirPath){
		this.AppdirPath =  appdirPath;
		println this.AppdirPath;
		LogFile = new File(AppdirPath+"/"+LOG_FILE_NAME);
	}

	//desc-start
	//Name:DelteFile
	//Description:Deletes the specified file
	//Parameter: fileName - File to delete
	//desc-end
	public def DelteFile(String fileName){
		try {
			new File(fileName).delete();
		} catch (Exception e) {
			// TODO: handle exception
			LogError(LogFile, e.message)
		}
	}

	private def GetNodeEndingFromNodeStart(String nodeStart){
		//ex nodeStart = <Command id="" >;
		String[] nodeSplit = nodeStart.split(" ");

		String nodeName = "</"+  nodeSplit[0].replace('<', '');

		println "new node name" +nodeName;

		return nodeName;
	}

	//desc-start
	//Name:CopyFileWithMove
	//Description:Copies the selected file, with an option to move.
	//Parameter: fileName - File to copy/move
	//Parameter: targetDir - Destination to copy/move to
	//Parameter: doMove - Keep original file true/false
	//desc-end
	public def CopyFileWithMove(String fileName,String targetDir, boolean doMove){
		try {
			CopyFile(fileName, targetDir);
			if	(doMove){
				new File(fileName).delete()
			}
		} catch (Exception e) {
			// TODO: handle exception
			LogError(LogFile, e.message)
		}

	}

	//desc-start
	//Name:ReplaceKeyValueInFileWithEquals
	//Description:Replaces the specified key's value in the file (key = value pairs), with the possiblity to create if not found.
	//Parameter: fileName - File to operate on
	//Parameter: key - Key to search for
	//Parameter: value - Value to add to the key supplied
	//Parameter: forceCreation - Create the key/value pair if not found true/false
	//desc-end
	public def ReplaceKeyValueInFileWithEquals(def fileName, def key, def value, boolean forceCreation){
		try{
			def textMatched =	FileTextMatched(new File(fileName), key)
			if(forceCreation){
				if	(textMatched.count ==0){
					//force create
					String keyValue = key + " = " + value;
					new File(fileName).append(keyValue);
				}else{
					//replace in file
					RegexReplaceInFile(new File(fileName), "($key).*", "\$1 = $value")
				}
			}else{
				if	(textMatched.count !=0){
					//replace in file
					RegexReplaceInFile(new File(fileName), "($key).*", "\$1 = $value")
				}
			}
		} catch (Exception e) {
			// TODO: handle exception
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"),e.message)
		}
	}

	//desc-start
	//Name:FindAndReplaceByXpath
	//Description:Replaces the specified XPath tag in the file , with the possiblity to create if not found under the specified parent xml presentation.
	//Parameter: fileName - File to operate on
	//Parameter: xPath - XPath to search for the targeted tag
	//Parameter: newValue - New Xml value to replace with
	//Parameter: parentXmlPresentation - Xml tag representing the parent, should match the parent tag name with all its attributes
	//Parameter: forceCreation - Create the new xml if not found true/false
	//desc-end
	public def FindAndReplaceByXpath(String fileName, String xPath, String newValue, String parentXmlPresentation, boolean forceCreation){
		try{
			String xmlData = ReadFile(new File(fileName));
			boolean isValidXPath = IsValidXpathNode(xmlData, xPath)
			if	(isValidXPath){
				ReplaceInFileUsingXpath(fileName,xPath,newValue)
			}else{
				//path not found
				if	(forceCreation && parentXmlPresentation != ""){
					String[] splitPath =  xPath.split('/')
					String parentXpath = "";
					for (int i = 0; i < splitPath.length-1; i++) {
						parentXpath = parentXpath +splitPath[i]
						if(i < (splitPath.length-2)){
							parentXpath = parentXpath + "/";
						}
					}
					println "Parent Xpath => " + parentXpath
					//got parent xpath
					AppendToNodeInFileUsingXpathAsChild(fileName,parentXpath,newValue,parentXmlPresentation)
				}
			}
		} catch (Exception e) {
			// TODO: handle exception
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"),e.message)
		}
	}

	//desc-start
	//Name:AppendToNodeInFileUsingXpathAsChild
	//Description:Adds the specified new value to the specified xpath as a child
	//Parameter: xmlFilePath - File to operate on
	//Parameter: xPath - XPath to search for the targeted tag
	//Parameter: newValue - New Xml value to replace with
	//Parameter: parentXmlPresentation - Xml tag representing the parent, should match the parent tag name with all its attributes
	//desc-end
	public String AppendToNodeInFileUsingXpathAsChild(String xmlFilePath, String xPath, String newValue, String parentXmlPresentation){
		try{
			// ./scripts/MXpress_logo_final.jpg
			def randomNumber = GenerateRandomNumber(1000);

			def endNode = GetNodeEndingFromNodeStart(parentXmlPresentation);

			CopyFile(AppdirPath+"/.ci/package/scripts/addChildXsl.xsl", AppdirPath+"/.ci/package/scripts/addChildXsl"+randomNumber+".xsl")

			File setTagTextValueFileXsl = new File(AppdirPath+"/.ci/package/scripts/addChildXsl"+randomNumber+".xsl");
			RegexReplaceInFile(setTagTextValueFileXsl, "#TARGETPATH#", xPath)
			RegexReplaceInFile(setTagTextValueFileXsl, "#REPLACEMENTXML#", newValue)
			RegexReplaceInFile(setTagTextValueFileXsl, "#STARTTAG#", parentXmlPresentation)
			RegexReplaceInFile(setTagTextValueFileXsl, "#ENDTAG#", endNode)

			RunXSLT(setTagTextValueFileXsl, new File(xmlFilePath))

			setTagTextValueFileXsl.delete();
		} catch (Exception e) {
			// TODO: handle exception
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"),e.message)
		}
	}


	//desc-start
	//Name:DeleteXmlTag
	//Description:Deletes the specified xml tag by XPath.
	//Parameter: xmlFilePath - File to operate on
	//Parameter: xPath - XPath to search for the targeted tag
	//Parameter: removeSubContents - Remove the targeted tag with all its children true/false
	//desc-end
	public String DeleteXmlTag(String xmlFilePath, String xPath, boolean removeSubContents){
		try{
			// ./scripts/MXpress_logo_final.jpg
			def randomNumber = GenerateRandomNumber(1000);
			if	(removeSubContents){
				CopyFile(AppdirPath+"/.ci/package/scripts/RemoveXslWithContent.xsl", AppdirPath+"/.ci/package/scripts/RemoveXslWithContent"+randomNumber+".xsl")
				File removeNodeFileXsl = new File(AppdirPath+"/.ci/package/scripts/RemoveXslWithContent"+randomNumber+".xsl");
				RegexReplaceInFile(removeNodeFileXsl, "#TARGETPATH#", xPath)
				RunXSLT(removeNodeFileXsl, new File(xmlFilePath))
				removeNodeFileXsl.delete();
			}else{
				CopyFile(AppdirPath+"/.ci/package/scripts/RemoveXslKeepContent.xsl", AppdirPath+"/.ci/package/scripts/RemoveXslKeepContent"+randomNumber+".xsl")
				File removeNodeFileXslKeepContent = new File(AppdirPath+"/.ci/package/scripts/RemoveXslKeepContent"+randomNumber+".xsl");
				RegexReplaceInFile(removeNodeFileXslKeepContent, "#TARGETPATH#", xPath)
				RunXSLT(removeNodeFileXslKeepContent, new File(xmlFilePath))
				removeNodeFileXslKeepContent.delete();
			}
		} catch (Exception e) {
			// TODO: handle exception
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"),e.message)
		}
	}


	//desc-start
	//Name:SetNodeValueInFileUsingXpath
	//Description:Sets the targeted node value to the desired new value irrespective of children or text value.
	//Parameter: xmlFilePath - File to operate on
	//Parameter: xPath - XPath to search for the targeted tag
	//Parameter: newValue - New value to replace
	//desc-end
	public String SetNodeValueInFileUsingXpath(String xmlFilePath, String xPath, String newValue){
		try{
			// ./scripts/MXpress_logo_final.jpg
			def randomNumber = GenerateRandomNumber(1000);
			CopyFile(AppdirPath+"/.ci/package/scripts/SetTagValueXsl.xsl", AppdirPath+"/.ci/package/scripts/SetTagValueXsl.xsl"+randomNumber+".xsl")

			File setTagTextValueFileXsl = new File(AppdirPath+"/.ci/package/scripts/SetTagValueXsl.xsl"+randomNumber+".xsl");
			RegexReplaceInFile(setTagTextValueFileXsl, "#TARGETPATH#", xPath)
			RegexReplaceInFile(setTagTextValueFileXsl, "#REPLACEMENTXML#", newValue)

			RunXSLT(setTagTextValueFileXsl, new File(xmlFilePath))

			setTagTextValueFileXsl.delete();
		} catch (Exception e) {
			// TODO: handle exception
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"),e.message)
		}
	}

	//desc-start
	//Name:SetNodeTextValueInFileUsingXpath
	//Description:Sets the targeted node text value to the desired new value.
	//Parameter: xmlFilePath - File to operate on
	//Parameter: xPath - XPath to search for the targeted tag, should contain /text()
	//Parameter: newValue - New value to replace
	//desc-end
	public String SetNodeTextValueInFileUsingXpath(String xmlFilePath, String xPath, String newValue){
		try{
			// ./scripts/MXpress_logo_final.jpg
			def randomNumber = GenerateRandomNumber(1000);
			CopyFile(AppdirPath+"/.ci/package/scripts/SetTagTextValueXsl.xsl", AppdirPath+"/.ci/package/scripts/SetTagTextValueXsl"+randomNumber+".xsl")

			File setTagTextValueFileXsl = new File(AppdirPath+"/.ci/package/scripts/SetTagTextValueXsl"+randomNumber+".xsl");
			RegexReplaceInFile(setTagTextValueFileXsl, "#TARGETPATH#", xPath)
			RegexReplaceInFile(setTagTextValueFileXsl, "#REPLACEMENTXML#", newValue)

			RunXSLT(setTagTextValueFileXsl, new File(xmlFilePath))

			setTagTextValueFileXsl.delete();
		} catch (Exception e) {
			// TODO: handle exception
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"),e.message)
		}
	}

	//desc-start
	//Name:AppendToNodeInFileUsingXpath
	//Description:Appends the specified xml after the specified xpath as a sibling.
	//Parameter: xmlFilePath - File to operate on
	//Parameter: xPath - XPath to search for the targeted tag
	//Parameter: newValue - New xml value to add
	//desc-end
	public String AppendToNodeInFileUsingXpath(String xmlFilePath, String xPath, String newValue){
		try{
			// ./scripts/MXpress_logo_final.jpg
			def randomNumber = GenerateRandomNumber(1000);
			CopyFile(AppdirPath+"/.ci/package/scripts/AppendToXpath.xsl", AppdirPath+"/.ci/package/scripts/AppendToXpath"+randomNumber+".xsl")

			File appendToNodeFileXsl = new File(AppdirPath+"/.ci/package/scripts/AppendToXpath"+randomNumber+".xsl");
			RegexReplaceInFile(appendToNodeFileXsl, "#TARGETPATH#", xPath)
			RegexReplaceInFile(appendToNodeFileXsl, "#REPLACEMENTXML#", newValue)

			RunXSLT(appendToNodeFileXsl, new File(xmlFilePath))

			appendToNodeFileXsl.delete();
		} catch (Exception e) {
			// TODO: handle exception
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"),e.message)
		}
	}

	private String ReplaceInFileUsingXpath(String xmlFilePath, String xPath, String newValue){
		try{
			// ./scripts/MXpress_logo_final.jpg
			def randomNumber = GenerateRandomNumber(1000);
			CopyFile(AppdirPath+"/.ci/package/scripts/ReplaceXSL.xsl", AppdirPath+"/.ci/package/scripts/ReplaceXSL"+randomNumber+".xsl")

			File replacementXslFile = new File(AppdirPath+"/.ci/package/scripts/ReplaceXSL"+randomNumber+".xsl");
			RegexReplaceInFile(replacementXslFile, "#TARGETPATH#", xPath)
			RegexReplaceInFile(replacementXslFile, "#REPLACEMENTXML#", newValue)

			RunXSLT(replacementXslFile, new File(xmlFilePath))

			replacementXslFile.delete();
		} catch (Exception e) {
			// TODO: handle exception
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"),e.message)
		}
	}

	private boolean IsValidXpathNode(String xmlData,String xPath){
		Collection<Object> foundPattern = processXmlRetString( xmlData, xPath);

		if(foundPattern.size == 0){
			return false;

		}else{
			return true;
		}
	}

	private Collection<Object> processXmlRetString( String xml, String xpathQuery ) {
		try{
			def xpath = XPathFactory.newInstance().newXPath()
			def builder     = DocumentBuilderFactory.newInstance().newDocumentBuilder()
			def inputStream = new ByteArrayInputStream( xml.bytes )
			def records     = builder.parse(inputStream).documentElement
			def nodes       = xpath.evaluate( xpathQuery, records, XPathConstants.NODESET )

			nodes.collect { node -> node }

		} catch (Exception e) {
			// TODO: handle exception
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"),e.message)
		}
	}

	def ProcessXml( def xml, def xpathQuery ) {
		def xpath = XPathFactory.newInstance().newXPath()
		def builder     = DocumentBuilderFactory.newInstance().newDocumentBuilder()
		def inputStream = new ByteArrayInputStream( xml.bytes )
		def records     = builder.parse(inputStream).documentElement
		println "as node: "+xpath.evaluate( xpathQuery, records)


		Node node = xpath.evaluate( xpathQuery, records, XPathConstants.NODE);
		println "node text: " + node.text()
		return xpath.evaluate( xpathQuery, records, XPathConstants.NODE)
	}

	//desc-start
	//Name:LaunchExecutable
	//Description:Launches the specified executable script.
	//Parameter: scriptPath - Path of script to launch
	//desc-end
	public def LaunchExecutable(def scriptPath){
		def ant = new AntBuilder()
		ant.exec(failonerror: "false",executable: scriptPath);
	}

	//desc-start
	//Name:LogInfo
	//Description:Logs the spcified text to a log file.
	//Parameter: file - File to log to
	//Parameter: logText - Log text
	//desc-end
	public def LogInfo(File file, def logText){
		try {
			file.append("\r\n"+logText);

		} catch (Exception ex) {
			LogError(file,"----ERROR----"+ex.message)
		}

	}

	private def LogError(File file,def logText){
		try {
			file.append("\r\n"+logText);

		} catch (Exception ex) {
			println ex.message
		}


	}

	//functional
	private def RunXSLT( File xslt, File xml){
		try {
			if (xml.isFile()) {
				println "Processing by XSL : $xml by $xslt"
				def writer = new StringWriter()
				def factory = TransformerFactory.newInstance()
				def reader = new StringReader(ReadFile(xslt))
				def streamS = new StreamSource(reader);
				def transformer = factory.newTransformer(streamS)
				transformer.transform(new StreamSource(new FileReader(xml.getPath())), new StreamResult(writer))
				xml.write(writer.toString())
				println "Writing new File: $xml"
			}
		} catch (Exception e) {
			// TODO: handle exception
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"),e.message)
		}
	}

	//functional
	private def RunXSLT(File xslt,File xml, def parameter,def parameterValue, def parameter1,def parameterValue1){
		try{
			if (xml.isFile()) {
				LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"),"Processing XMl with XSLT: $xml With $xslt")
				LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "Parameters:")
				LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "$parameter $parameterValue")
				LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "$parameter1 $parameterValue1")
				def writer = new StringWriter()
				def factory = TransformerFactory.newInstance()
				def reader = new StringReader(ReadFile(xslt))
				def streamS = new StreamSource(reader);
				def transformer = factory.newTransformer(streamS)
				transformer.setParameter(parameter,parameterValue);
				transformer.setParameter(parameter1,parameterValue1);
				transformer.transform(new StreamSource(new FileReader(xml.getPath())), new StreamResult(writer))
				xml.write(writer.toString())
				LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "Writing new File: $xml")
			}
		} catch (Exception e) {
			// TODO: handle exception
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"),e.message)
		}
	}

	//functional
	private def RunXSLT(File xslt,File xml, def parameter,def parameterValue){
		try{
			if (xml.isFile()) {
				LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"),"Processing XMl with XSLT: $xml With $xslt")
				LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"),"Parameters:")
				LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "$parameter $parameterValue")
				def writer = new StringWriter()
				def factory = TransformerFactory.newInstance()
				def reader = new StringReader(ReadFile(xslt))
				def streamS = new StreamSource(reader);
				def transformer = factory.newTransformer(streamS)
				transformer.setParameter(parameter,parameterValue);
				transformer.transform(new StreamSource(new FileReader(xml.getPath())), new StreamResult(writer))
				xml.write(writer.toString())
				LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "Writing new File: $xml")
			}
		} catch (Exception e) {
			// TODO: handle exception
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"),e.message)
		}
	}

	//functional
	private def processFileInplace(file, Closure processText) {
		try{
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "Processing File in Place: $file")
			def text = file.text
			file.write(processText(text))
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "Done Processing File in Place: $file")

		} catch (Exception e) {
			// TODO: handle exception
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"),e.message)
		}
	}

	//desc-start
	//Name:RegexReplaceInFile
	//Description:Searches the spcified file for matches to the pattern and replaces it with the replacement.
	//Parameter: file - File to search in
	//Parameter: pattern - Pattern to search for
	//Parameter: replacement - Replacement to found text
	//desc-end
	public def RegexReplaceInFile(File targetFile,def pattern,def replacement){
		try{
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "Applying Regex to file: $targetFile")
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "Pattern: $pattern")
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "Replacement: $replacement")

			processFileInplace(targetFile){ text -> text.replaceAll(/$pattern/,replacement)}
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "Done Applying Regex to file: $targetFile")

		} catch (Exception e) {
			// TODO: handle exception
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"),e.message)
		}
	}

	//desc-start
	//Name:DeleteDirectory
	//Description:Deletes the spcified directory with all its children.
	//Parameter: directory - Directory path to delete
	//desc-end
	public def DeleteDirectory(def directory){
		try {
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "Deleting Directory: $directory")

			new AntBuilder().delete(dir: directory)
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "Done Deleting Directory: $directory")
		} catch (Exception e) {
			println e.toString();
		}
	}

	//desc-start
	//Name:BackupFile
	//Description:Backsup the spcified file to the backup directory.
	//Parameter: fileName - File path to delete
	//Parameter: ApplicationDirectoryPath - application directory of the deployed environment
	//desc-end
	public def BackupFile(def fileName,def ApplicationDirectoryPath){
		try {
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "Backing up File: $fileName")
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "Backup Dir: $BackupDir")
			def appDir = ApplicationDirectoryPath;
			def backupFileName=fileName.replace (ApplicationDirectoryPath, this.BackupDir)
			CopyFile(fileName, backupFileName)
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "Done Backing up File: $fileName to $backupFileName")
		} catch (Exception e) {
			println e.toString();
		}
	}


	//desc-start
	//Name:BackupFile
	//Description:Backsup the spcified file to the specified backup directory.
	//Parameter: fileName - File path to delete
	//Parameter: ApplicationDirectoryPath - application directory of the deployed environment
	//Parameter: BackupDirectoryPath - backup directory of the deployed environment
	//desc-end
	public def BackupFile(def fileName,def ApplicationDirectoryPath, def BackupDirectoryPath){
		try {
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "Backing up File: $fileName")
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "Backup Dir: $BackupDirectoryPath")
			def appDir = ApplicationDirectoryPath;
			def backupFileName=fileName.replace (ApplicationDirectoryPath, BackupDirectoryPath)
			CopyFile(fileName, backupFileName)
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "Done Backing up File: $fileName to $backupFileName")

		} catch (Exception e) {
			println e.toString();
		}
	}

	//desc-start
	//Name:ChmodDir
	//Description:Chmods the specified directory to the supplied access attributes.
	//Parameter: Dir - Directory to chmod
	//Parameter: mod - New mod to apply ex:777
	//desc-end
	public def ChmodDir(File Dir, def mod){
		try{
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "Applying Chmod to Dir:  $Dir")
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "Mod:  $mod")
			def commandText = "chmod "+mod+" "+Dir;
			def returnValue = ExecuteCommandInShell(commandText, Dir);
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "Done Applyinh Chmod:  $Dir")
			return returnValue
		}
		catch(Exception ex){
			println ex.toString();
		}
	}

	//desc-start
	//Name:ChmodFile
	//Description:chmods the specified file to the supplied access attributes.
	//Parameter: fileName - File to chmod
	//Parameter: mod - New mod to apply ex:777
	//desc-end
	public def ChmodFile(File fileName, def mod){
		try{
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "Applying Chmod to File:  $fileName")
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "Mod:  $mod")
			def commandText = "chmod "+mod+" "+fileName;
			def returnValue =  ExecuteCommandInShell(commandText, fileName.parentFile);
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "Applying Chmod to Dir:  $fileName")
			return returnValue;
		}
		catch(Exception ex){
			println ex.toString();
		}
	}

	//desc-start
	//Name:ExecuteCommandInShell
	//Description:Executes the specified command in the supplied directory.
	//Parameter: commandText - command text
	//Parameter: directoryContext - The directory in which we need to execute the command
	//desc-end
	public def ExecuteCommandInShell(String commandText, File directoryContext){
		try{
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "Start Execute Command in Shell:  $commandText")
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "Context:  $directoryContext")


			def returnValue = commandText.execute(null,directoryContext).toString();
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "Return Value:  $returnValue")

			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "End Execute Command in Shell:  $commandText")

			return returnValue;
		}
		catch(Exception ex){
			println ex.toString();
		}
	}

	//desc-start
	//Name:ExecuteScriptInShell
	//Description:Executes the specified script.
	//Parameter: fileName - The script path.
	//desc-end
	public def ExecuteScriptInShell(File fileName){
		def fileText = fileName.getText();
		try{
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "Execute Script In Shell:  $fileName")
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "Script Text:  $fileText")

			def returnValue =  fileName.toString().execute(null,fileName.parentFile).toString();
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "Return Value:  $returnValue")
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "Execute Script In Shell:  $fileName")

			return returnValue

		}
		catch(Exception ex){
			println ex.toString();
		}
	}

	//desc-start
	//Name:CopyFile
	//Description:Copies the source file to the destination file.
	//Parameter: sourceFile - Source file to copy.
	//Parameter: destinationFile - Destination file to copy to.
	//desc-end
	public def CopyFile(def sourceFile,def destinationFile){
		try{
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "Copy File From:  $sourceFile")
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "Copy File To:  $destinationFile")

			def ant = new AntBuilder();
			ant.copy(file: sourceFile,tofile: destinationFile)
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "End Copy File To:  $destinationFile")

		} catch (Exception e) {
			// TODO: handle exception
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"),e.message)
		}
	}

	//functional
	private def ReadFile(File fileName){
		def fileText;
		try{
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "Read File:  $fileName")

			fileText = fileName.getText();
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "End Read File:  $fileName")

		} catch (Exception e) {
			// TODO: handle exception
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"),e.message)
		}
		return fileText
	}

	//desc-start
	//Name:CopyAllFiles
	//Description:Copies all the files within the specified directory to the destination directory.
	//Parameter: fromDirectory - Source directory to copy.
	//Parameter: toDirectory - Destination directory to copy to.
	//desc-end
	public def CopyAllFiles(def fromDirectory,def toDirectory){
		def ant = new AntBuilder();
		try{
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "Copy All Files From:  $fromDirectory")
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "Copy All Files To:  $toDirectory")

			ant.copy(toDir:toDirectory,overwrite:true) {
				fileset(dir:fromDirectory){
				}
			}

			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "End Copy All Files To:  $toDirectory")
		} catch (Exception e) {
			// TODO: handle exception
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"),e.message)
		}
	}

	//functional
	private def GenerateRandomNumber(def maxNumber){
		LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "Generate Random:  $maxNumber")
		def random= new Random();
		Integer number =  random.nextInt(maxNumber);
		LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "Done Generate Random:  $number")
		return number;
	}

	//functional
	private def FileTextMatched(File fileName, def pattern){
		def matcher;
		try{
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "Get File Text Matched:  $fileName")
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "Pattern:  $pattern")
			def fileText = fileName.getText();
			matcher = "test" =~ /te/
			assert matcher instanceof Matcher
			matcher = fileText =~ pattern
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"), "End Get File Text Matched:  $fileName")

		} catch (Exception e) {
			// TODO: handle exception
			LogInfo(new File(AppdirPath+"/$LOG_FILE_NAME"),e.message)
		}
		return matcher
	}
}
