  UPDATE DPA_FATTURA SET templateXML = '<?xml version="1.0" encoding="UTF-8"?><p:FatturaElettronica versione="1.1" xmlns:ds="http://www.w3.org/2000/09/xmldsig#" xmlns:p="http://www.fatturapa.gov.it/sdi/fatturapa/v1.1" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"><FatturaElettronicaHeader><DatiTrasmissione><IdTrasmittente><IdPaese></IdPaese><IdCodice></IdCodice></IdTrasmittente><ProgressivoInvio></ProgressivoInvio><FormatoTrasmissione></FormatoTrasmissione><CodiceDestinatario></CodiceDestinatario><ContattiTrasmittente><Telefono></Telefono><Email></Email></ContattiTrasmittente></DatiTrasmissione><CedentePrestatore><DatiAnagrafici><IdFiscaleIVA><IdPaese></IdPaese><IdCodice></IdCodice></IdFiscaleIVA><Anagrafica><Denominazione></Denominazione></Anagrafica><RegimeFiscale>RF01</RegimeFiscale></DatiAnagrafici><Sede><Indirizzo></Indirizzo><NumeroCivico></NumeroCivico><CAP></CAP><Comune></Comune><Provincia></Provincia><Nazione></Nazione></Sede><IscrizioneREA><Ufficio></Ufficio><NumeroREA></NumeroREA><CapitaleSociale></CapitaleSociale><SocioUnico></SocioUnico><StatoLiquidazione></StatoLiquidazione></IscrizioneREA><RiferimentoAmministrazione></RiferimentoAmministrazione></CedentePrestatore><CessionarioCommittente><DatiAnagrafici><IdFiscaleIVA><IdPaese></IdPaese><IdCodice></IdCodice></IdFiscaleIVA><Anagrafica><Denominazione></Denominazione></Anagrafica></DatiAnagrafici><Sede><Indirizzo></Indirizzo><NumeroCivico></NumeroCivico><CAP></CAP><Comune></Comune><Provincia></Provincia><Nazione></Nazione></Sede></CessionarioCommittente></FatturaElettronicaHeader><FatturaElettronicaBody><DatiGenerali><DatiGeneraliDocumento><TipoDocumento></TipoDocumento><Divisa></Divisa><Data></Data><Numero></Numero><ImportoTotaleDocumento></ImportoTotaleDocumento></DatiGeneraliDocumento><DatiOrdineAcquisto><IdDocumento></IdDocumento><CodiceCUP></CodiceCUP><CodiceCIG></CodiceCIG></DatiOrdineAcquisto><DatiContratto><IdDocumento></IdDocumento><CodiceCUP></CodiceCUP><CodiceCIG></CodiceCIG></DatiContratto></DatiGenerali><DatiBeniServizi></DatiBeniServizi><DatiPagamento><CondizioniPagamento></CondizioniPagamento><DettaglioPagamento><ModalitaPagamento></ModalitaPagamento><DataRiferimentoTerminiPagamento></DataRiferimentoTerminiPagamento><GiorniTerminiPagamento></GiorniTerminiPagamento><ImportoPagamento></ImportoPagamento><IstitutoFinanziario></IstitutoFinanziario><IBAN></IBAN><BIC></BIC></DettaglioPagamento></DatiPagamento></FatturaElettronicaBody></p:FatturaElettronica>'
  UPDATE DPA_FATTURA SET formato_trasmissione = 'SDI11'
  UPDATE DPA_FATTURA SET esigibilita_IVA = 'S'