import { Box } from '@chakra-ui/react'
import { Editor } from '@tinymce/tinymce-react'
import React, { FC } from 'react'
import { Project } from '../../../../../api/hooks/project'

interface Props {
  currentText: string
  onChange: (key: keyof Project, val: string) => void
}

export const TinyEditor: FC<Props> = ({ currentText, onChange }) => {
  const onEditorChange = (a: string, editor: any) => {
    console.log(a)
    if (currentText !== a) {
      onChange('description', a)
    }
  }

  return (
    <Box paddingX="22px" w={'100%'} paddingBottom="22px">
      <Editor
        initialValue={currentText}
        init={{
          height: '300px',
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
