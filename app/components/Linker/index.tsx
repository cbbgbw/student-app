import { Link } from '@chakra-ui/react'
import { useRouter } from 'next/router'
import React, { FC } from 'react'

export enum LinkType {
  'Projects' = 'projects',
  'Subjects' = 'subjects',
}

interface Props {
  type: LinkType
  typeKey: string
}

export const Linker: FC<Props> = ({ children, type, typeKey }) => {
  const { push } = useRouter()

  return (
    <Link
      onClick={async () => {
        await push(`${type}\\${typeKey}`)
      }}
    >
      {children}
    </Link>
  )
}
