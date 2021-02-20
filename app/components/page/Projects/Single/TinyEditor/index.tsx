import { Box } from '@chakra-ui/react'
import { Editor } from '@tinymce/tinymce-react'
import React from 'react'

export const TinyEditor = () => {
  const onEditorChange = (a: string, editor: any) => {
    console.log(a)
    console.log(editor)
  }

  return (
    <Box paddingX={'22px'} paddingBottom={'22px'}>
      <Editor
        initialValue={'<p>Tutaj możesz wykonać notatki</p>'}
        init={{
          height: '300px',
          menubar: false,
          plugins: [
            'advlist autolink lists link image charmap print preview anchor',
            'searchreplace visualblocks code fullscreen',
            'insertdatetime media table paste code help wordcount',
          ],
        }}
        apiKey="fbftxisijv35msp1gkdkif771h6pz4eotbwdj54bautslzac"
        onEditorChange={onEditorChange}
      />
    </Box>
  )
}
