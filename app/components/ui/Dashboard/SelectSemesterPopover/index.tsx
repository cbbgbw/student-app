import React, { useEffect, useState } from 'react'
import { Popover, PopoverArrow } from '@chakra-ui/popover'
import {
  Button,
  PopoverBody,
  PopoverCloseButton,
  PopoverContent,
  PopoverHeader,
  PopoverTrigger,
  Portal,
  Select,
} from '@chakra-ui/react'
import { SemesterNumberInput } from '../../../SemesterSelect'
import { useSemesters } from '../../../../api/hooks/semester'

export const SelectSemesterPopover = () => {
  const {
    semesters,
    currentSemester,
    changeSemesterToExisting,
    changeSemesterToNew,
  } = useSemesters()

  const [selectedSemester, setSelectedSemester] = useState<string>()
  const [newSemesterNumber, setNewSemesterNumber] = useState<number>()

  useEffect(() => {
    setSelectedSemester(currentSemester?.[0])
    setNewSemesterNumber(Number(currentSemester?.[1]) + 1)
  }, [semesters])

  const generateSemestersItems = () =>
    semesters &&
    Object.keys(semesters).map((key: string) => (
      <option selected={key === currentSemester?.[0]} key={key} value={key}>
        Semestr {semesters?.[key]}
      </option>
    ))

  const onSemesterSubmit = async () => {
    if (selectedSemester === 'new' && newSemesterNumber) {
      await changeSemesterToNew(newSemesterNumber)
    } else if (selectedSemester) {
      await changeSemesterToExisting(selectedSemester)
    }
  }

  return (
    <Popover placement="auto-start">
      <PopoverTrigger>
        <Button variant="ghost">Semestr {currentSemester?.[1]}</Button>
      </PopoverTrigger>
      <Portal>
        <PopoverContent>
          <PopoverArrow />
          <PopoverHeader>Wybierz semestr</PopoverHeader>
          <PopoverCloseButton />
          <PopoverBody>
            <Select
              onChange={(e) => setSelectedSemester(e.target.value)}
              mb={4}
            >
              {semesters && (
                <>
                  {generateSemestersItems()}
                  <option value="new">Dodaj nowy</option>
                </>
              )}
            </Select>
            {selectedSemester === 'new' && (
              <SemesterNumberInput
                onChange={(val) => setNewSemesterNumber(val)}
                semester={newSemesterNumber}
              />
            )}
            <Button
              disabled={
                Number(selectedSemester) === Number(currentSemester?.[1])
              }
              onClick={() => onSemesterSubmit()}
            >
              {selectedSemester === 'new'
                ? 'Utwórz semestr oraz wybierz'
                : 'Wybierz semestr'}
            </Button>
          </PopoverBody>
        </PopoverContent>
      </Portal>
    </Popover>
  )
}
