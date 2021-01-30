import { FC } from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faPlus } from '@fortawesome/free-solid-svg-icons'
import { Button } from '@chakra-ui/react'

export interface AddProps {
  name: string
  onClick: () => void
}

export const Add: FC<AddProps> = ({ name, onClick }) => (
  <Button
    h={160}
    w={160}
    d="flex"
    alignItems="flex-start"
    flexDir="column"
    justifyContent="space-around"
    onClick={() => onClick()}
  >
    <h1>
      Dodaj <br />
      {name}
    </h1>
    <FontAwesomeIcon icon={faPlus} size="3x" />
  </Button>
)
