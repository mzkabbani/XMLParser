package murex.Migration;
import java.util.Formatter.DateTime;
import org.codehaus.groovy.runtime.DateGroovyMethods;
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
			LogInfo(LogFile,"Start Append to text file: $fileName")
			new File(fileName).append("\r\n"+textToAppend);
			LogInfo(LogFile,"End Append to text file: $fileName")
		} catch (Exception e) {
			// TODO: handle exception
			LogInfo(LogFile,e.message)
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
			if(new File( LogFile.getParent()).mkdirs()){
				LogInfo(LogFile, "Log Dir Setup Completed!")				
				}
			LogFile.createNewFile()
			
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
	//Name:DeleteFile
	//Description:Deletes the specified file
	//Parameter: fileName - File to delete
	//desc-end
	public def DeleteFile(String fileName){
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
			LogInfo(LogFile,e.message)
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
			LogInfo(LogFile,e.message)
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
			LogInfo(LogFile,e.message)
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
			LogInfo(LogFile,e.message)
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
			LogInfo(LogFile,e.message)
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
			LogInfo(LogFile,e.message)
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
			LogInfo(LogFile,e.message)
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
			LogInfo(LogFile,e.message)
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
			LogInfo(LogFile,e.message)
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
			
			file.append("\r\n"+DateGroovyMethods.format(new Date(), 'yyyy/MM/dd hh:mm:ss')+"  "+logText);

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
			LogInfo(LogFile,e.message)
		}
	}

	//functional
	private def RunXSLT(File xslt,File xml, def parameter,def parameterValue, def parameter1,def parameterValue1){
		try{
			if (xml.isFile()) {
				LogInfo(LogFile,"Processing XMl with XSLT: $xml With $xslt")
				LogInfo(LogFile, "Parameters:")
				LogInfo(LogFile, "$parameter $parameterValue")
				LogInfo(LogFile, "$parameter1 $parameterValue1")
				def writer = new StringWriter()
				def factory = TransformerFactory.newInstance()
				def reader = new StringReader(ReadFile(xslt))
				def streamS = new StreamSource(reader);
				def transformer = factory.newTransformer(streamS)
				transformer.setParameter(parameter,parameterValue);
				transformer.setParameter(parameter1,parameterValue1);
				transformer.transform(new StreamSource(new FileReader(xml.getPath())), new StreamResult(writer))
				xml.write(writer.toString())
				LogInfo(LogFile, "Writing new File: $xml")
			}
		} catch (Exception e) {
			// TODO: handle exception
			LogInfo(LogFile,e.message)
		}
	}

	//functional
	private def RunXSLT(File xslt,File xml, def parameter,def parameterValue){
		try{
			if (xml.isFile()) {
				LogInfo(LogFile,"Processing XMl with XSLT: $xml With $xslt")
				LogInfo(LogFile,"Parameters:")
				LogInfo(LogFile, "$parameter $parameterValue")
				def writer = new StringWriter()
				def factory = TransformerFactory.newInstance()
				def reader = new StringReader(ReadFile(xslt))
				def streamS = new StreamSource(reader);
				def transformer = factory.newTransformer(streamS)
				transformer.setParameter(parameter,parameterValue);
				transformer.transform(new StreamSource(new FileReader(xml.getPath())), new StreamResult(writer))
				xml.write(writer.toString())
				LogInfo(LogFile, "Writing new File: $xml")
			}
		} catch (Exception e) {
			// TODO: handle exception
			LogInfo(LogFile,e.message)
		}
	}

	//functional
	private def processFileInplace(file, Closure processText) {
		try{
			LogInfo(LogFile, "Processing File in Place: $file")
			def text = file.text
			file.write(processText(text))
			LogInfo(LogFile, "Done Processing File in Place: $file")

		} catch (Exception e) {
			// TODO: handle exception
			LogInfo(LogFile,e.message)
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
			LogInfo(LogFile, "Applying Regex to file: $targetFile")
			LogInfo(LogFile, "Pattern: $pattern")
			LogInfo(LogFile, "Replacement: $replacement")

			processFileInplace(targetFile){ text -> text.replaceAll(/$pattern/,replacement)}
			LogInfo(LogFile, "Done Applying Regex to file: $targetFile")

		} catch (Exception e) {
			// TODO: handle exception
			LogInfo(LogFile,e.message)
		}
	}

	//desc-start
	//Name:DeleteDirectory
	//Description:Deletes the spcified directory with all its children.
	//Parameter: directory - Directory path to delete
	//desc-end
	public def DeleteDirectory(def directory){
		try {
			LogInfo(LogFile, "Deleting Directory: $directory")

			new AntBuilder().delete(dir: directory)
			LogInfo(LogFile, "Done Deleting Directory: $directory")
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
			LogInfo(LogFile, "Backing up File: $fileName")
			LogInfo(LogFile, "Backup Dir: $BackupDir")
			def appDir = ApplicationDirectoryPath;
			def backupFileName=fileName.replace (ApplicationDirectoryPath, this.BackupDir)
			CopyFile(fileName, backupFileName)
			LogInfo(LogFile, "Done Backing up File: $fileName to $backupFileName")
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
			LogInfo(LogFile, "Backing up File: $fileName")
			LogInfo(LogFile, "Backup Dir: $BackupDirectoryPath")
			def appDir = ApplicationDirectoryPath;
			def backupFileName=fileName.replace (ApplicationDirectoryPath, BackupDirectoryPath)
			CopyFile(fileName, backupFileName)
			LogInfo(LogFile, "Done Backing up File: $fileName to $backupFileName")

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
			LogInfo(LogFile, "Applying Chmod to Dir:  $Dir")
			LogInfo(LogFile, "Mod:  $mod")
			def commandText = "chmod "+mod+" "+Dir;
			def returnValue = ExecuteCommandInShell(commandText, Dir);
			LogInfo(LogFile, "Done Applyinh Chmod:  $Dir")
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
			LogInfo(LogFile, "Applying Chmod to File:  $fileName")
			LogInfo(LogFile, "Mod:  $mod")
			def commandText = "chmod "+mod+" "+fileName;
			def returnValue =  ExecuteCommandInShell(commandText, fileName.parentFile);
			LogInfo(LogFile, "Applying Chmod to Dir:  $fileName")
			return returnValue;
		}
		catch(Exception ex){
			println ex.toString();
		}
	}

	//desc-start
	//Name:ConvertDos2Unix
	//Description: Converts plain text files in DOS format to UNIX format.
	//Parameter: fileName - File path to convert	
	//desc-end
	public def ConvertDos2Unix(def fileName){
		try{
			LogInfo(LogFile, "Start Applying dos2unix conversion on:  $fileName")
			
			def commandText = "dos2unix "+fileName;
			def returnValue =  ExecuteCommandInShell(commandText, new File(fileName).parentFile);
			LogInfo(LogFile, "End Applying dos2unix conversion on:  $fileName")
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
			LogInfo(LogFile, "Start Execute Command in Shell:  $commandText")
			LogInfo(LogFile, "Context:  $directoryContext")


			def returnValue = commandText.execute(null,directoryContext).toString();
			LogInfo(LogFile, "Return Value:  $returnValue")

			LogInfo(LogFile, "End Execute Command in Shell:  $commandText")

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
			LogInfo(LogFile, "Execute Script In Shell:  $fileName")
			LogInfo(LogFile, "Script Text:  $fileText")

			def returnValue =  fileName.toString().execute(null,fileName.parentFile).toString();
			LogInfo(LogFile, "Return Value:  $returnValue")
			LogInfo(LogFile, "Execute Script In Shell:  $fileName")

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
			LogInfo(LogFile, +" Copy File From:  $sourceFile")
			LogInfo(LogFile, "Copy File To:  $destinationFile")

			def ant = new AntBuilder();
			ant.copy(file: sourceFile,tofile: destinationFile)
			LogInfo(LogFile, "End Copy File To:  $destinationFile")

		} catch (Exception e) {
			// TODO: handle exception
			LogInfo(LogFile,e.message)
		}
	}

	//functional
	private def ReadFile(File fileName){
		def fileText;
		try{
			LogInfo(LogFile, "Read File:  $fileName")

			fileText = fileName.getText();
			LogInfo(LogFile, "End Read File:  $fileName")

		} catch (Exception e) {
			// TODO: handle exception
			LogInfo(LogFile,e.message)
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
			LogInfo(LogFile, "Copy All Files From:  $fromDirectory")
			LogInfo(LogFile, "Copy All Files To:  $toDirectory")

			ant.copy(toDir:toDirectory,overwrite:true) {
				fileset(dir:fromDirectory){
				}
			}

			LogInfo(LogFile, "End Copy All Files To:  $toDirectory")
		} catch (Exception e) {
			// TODO: handle exception
			LogInfo(LogFile,e.message)
		}
	}

	//functional
	private def GenerateRandomNumber(def maxNumber){
		LogInfo(LogFile, "Generate Random:  $maxNumber")
		def random= new Random();
		Integer number =  random.nextInt(maxNumber);
		LogInfo(LogFile, "Done Generate Random:  $number")
		return number;
	}

	//functional
	private def FileTextMatched(File fileName, def pattern){
		def matcher;
		try{
			LogInfo(LogFile, "Get File Text Matched:  $fileName")
			LogInfo(LogFile, "Pattern:  $pattern")
			def fileText = fileName.getText();
			matcher = "test" =~ /te/
			assert matcher instanceof Matcher
			matcher = fileText =~ pattern
			LogInfo(LogFile, "End Get File Text Matched:  $fileName")

		} catch (Exception e) {
			// TODO: handle exception
			LogInfo(LogFile,e.message)
		}
		return matcher
	}
}
