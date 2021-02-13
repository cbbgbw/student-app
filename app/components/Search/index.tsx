import { Input, InputGroup, InputLeftElement } from '@chakra-ui/react'

import SearchIcon from '../../public/icons/dashboard/search.svg'
import React from 'react'

export const Search = () => {
  return (
    <InputGroup mt={16}>
      <InputLeftElement
        pointerEvents="none"
        children={<SearchIcon />}
        fill="black"
      />
      <Input w={400} placeholder="Wyszukaj przedmiot, projekt, wydarzenie" />
    </InputGroup>
  )
}
