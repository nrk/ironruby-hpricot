module TestFiles
    Dir.chdir(File.dirname(__FILE__)) do
        Dir['files/*.{html,xhtml,xml}'].each do |fname|
            const_set fname[%r!/(\w+)\.\w+$!, 1].upcase, IO.read(fname)
        end
    end
end

class String
    unless defined? "".lines
        alias lines to_a
    end
end
