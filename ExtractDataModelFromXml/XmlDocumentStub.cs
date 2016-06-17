using System.Xml;

namespace ExtractDataModelFromXml
{
    public class XmlDocumentStub
    {
        private XmlDocument _xml;

        public XmlDocument Xml
        {
            get
            {
                if (_xml == null)
                {
                    _xml = new XmlDocument();
                    _xml.LoadXml(EnterpriseInvitationNotification.Trim());
                }

                return _xml;
            }
        }


        private const string EnterpriseInvitationNotification = @"
<?xml version=""1.0"" encoding=""utf-8""?>
<NotificationDefinition>
    <Paragraph>
        <Title>
            <Resource Key = ""InvitationNotification_EnterpriseInvitation"" />

        </Title>

    </Paragraph>

    <Paragraph>

        <Resource Key=""InvitationNotification_YouHaveBeenInvited"" />
    </Paragraph>
    <Paragraph />
    <Table>
        <Row>
            <CellLeft>
                <Bold>
                    <Resource Key = ""NotificationDefinition_Name"" />
                </Bold>
            </CellLeft>
            <CellRight>
                <Data ID=""FullName"">Martin Scorcese</Data>
            </CellRight>
        </Row>
        <Row>
            <CellLeft>
                <Bold>
                    <Resource Key=""NotificationDefinition_Email"" />
                 </Bold>
             </CellLeft>
             <CellRight>
                 <Data ID=""Email""> Administrator@daptiv.com</Data>
            </CellRight>
        </Row>
        <Row>
            <CellLeft>
                <Bold>
                    <Resource Key=""NotificationDefinition_EnterpriseName"" />
                 </Bold>
             </CellLeft>
             <CellRight>
                 <Data ID=""Title"">GWalwcOlaIKG</Data>
             </CellRight>
         </Row>
     </Table>
     <PageLink Value=""NotificationDefinition_LinkToLogin"">
         <Data ID=""PageLink"">http://dev.daptiv.com/</Data>
    </PageLink>
</NotificationDefinition>
";
    }
}
