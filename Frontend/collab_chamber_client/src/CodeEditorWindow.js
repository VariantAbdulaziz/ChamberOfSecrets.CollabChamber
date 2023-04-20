import React, { useState, useEffect } from "react";
import { HubConnectionBuilder, HttpTransportType } from '@microsoft/signalr';
import { diff_match_patch } from 'diff-match-patch';

import Editor from "@monaco-editor/react";

const BASE_URL = 'http://localhost:5035';

const CodeEditorWindow = () => {
  const [ connection, setConnection ] = useState(null);
  const [ local, setLocal ] = useState("");
  const [ shadow, setShadow ] = useState("");
  const [ localEdit, setLocalEdit ] = useState({ patches: "", dirty: true });
  const [ remoteEdit, setRemoteEdit ] = useState({ patches: "", dirty: true });
  const [ dirty, setDirty ] = useState(false);

  async function sendEdit(edit) {
    try {
      await connection.send('SendEdit', edit);
    }
    catch(e) {
      console.log(e);
    }
    setDirty(false);
  }

  useEffect(() => {
    
    const newConnection = new HubConnectionBuilder()
        .withUrl(`${BASE_URL}/collabchamber`, {
            skipNegotiation: true,
            transport: HttpTransportType.WebSockets
        })
        .withAutomaticReconnect()
        .build();

    setConnection(newConnection);
  }, []);

  useEffect(() => {
    if (connection) {
        connection.start()
            .then(result => {
                console.log('Connected!');
                connection.on('EditReceived', edit => {
                  setRemoteEdit(edit);
                });
                connection.on('Dirty', () => {
                  console.log("dirty...");
                  setDirty(true);
                });
            })
            .catch(e => console.log('Connection failed: ', e));
    }

  }, [connection]);

  useEffect(() => {
    let newShadow = shadow;
    let dmp = new diff_match_patch();
    let diffs = dmp.diff_main(newShadow, local);
    let patches = dmp.patch_make(diffs);
    let result = dmp.patch_apply(patches, newShadow);
    newShadow = result[0];
    const newEdit = {
        patches: dmp.patch_toText(patches),
        dirty: false
    };
    console.log("in...");
    setLocalEdit(newEdit);
    setShadow(newShadow);
  }, [local]);

  useEffect(() => {
    console.log(`${shadow} | ${local}`);
  }, [shadow, local]);

  useEffect(() => {
    console.log(`b> ${localEdit.patches}`);
    sendEdit(localEdit);
  }, [localEdit]);

  useEffect(() => {
    console.log(`b> ${localEdit.patches}`);
    sendEdit({ patches: "" , dirty: true});
  }, [dirty]);

  useEffect(() => {
    try{
      let newShadow = shadow;
      let dmp = new diff_match_patch();
      let patches = dmp.patch_fromText(remoteEdit.patches);
      let result = dmp.patch_apply(patches, newShadow);
      newShadow = result[0];
      setShadow(newShadow);
      result = dmp.patch_apply(patches, local);
      let newLocal = result[0];
      setLocal(newLocal);
    } catch (e) {
      console.log(e);
    }
  }, [remoteEdit]);

  const handleEditorChange = async (val) => {
    setLocal(val);
  };

  return (
    <div className="overlay rounded-md overflow-scroll w-full h-full shadow-4xl">
      <Editor
        height="100vh"
        width={`100%`}
        language="javascript"
        value={local}
        defaultValue=""
        onChange={handleEditorChange}
        theme="vs-dark"
      />
    </div>
  );
};

export default CodeEditorWindow;